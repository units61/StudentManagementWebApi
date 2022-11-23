using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.CreateTeacher;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;
using TestSetup;
using Xunit;


namespace Tests.TeacherManagementWebApi.UnitTests.Application.TeacherOperation.Command.CreateTeacher
{
    public class CreateTeacherCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public CreateTeacherCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistTeacherIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var teacher = new Teacher() {Name="ANILS", SurName="KOCAYİĞİTS", Qulification="MATEMATİKS"};
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            CreateTeacherCommand command = new CreateTeacherCommand(_context, _mapper);
            command.Model = new CreateTeacherModel() {Name = teacher.Name, SurName = teacher.SurName, Qulification = teacher.Qulification};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öğretmen zaten mevcut ...");
        }

        
        [Fact]
        public void WhenValidInputsAreGiven_Teacher_ShouldBeCreated()
        {
            //arrange
            CreateTeacherCommand command = new CreateTeacherCommand(_context,_mapper);
            CreateTeacherModel model = new CreateTeacherModel() {Name="ANILS", SurName="KOCAYİĞİTS", Qulification="MATEMATİKS"};
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var teacher = _context.Teachers.SingleOrDefault(teacher => teacher.Name == model.Name && teacher.SurName == model.SurName && teacher.Qulification == model.Qulification);
            teacher.Should().NotBeNull();
        }
    }
}
using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.Commands.CreateStudent;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TestSetup;
using Xunit;


namespace Tests.StudentManagementWebApi.UnitTests.Application.StudentOperation.Command.CreateStudent
{
    public class CreateStudentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
        private readonly IMapper _mapper;

        public CreateStudentCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistStudentIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var student = new Student() {Name="MATEMATİKS", SurName="MATEMATİKS", PhoneNumber="5321234567", Adress="BEŞİKTAŞ", Email="muhammetaygun@mail.com"};
            _context.Students.Add(student);
            _context.SaveChanges();

            CreateStudentCommand command = new CreateStudentCommand(_context, _mapper);
            command.Model = new CreateStudentModel() {Name = student.Name, SurName = student.SurName, PhoneNumber = student.PhoneNumber, Adress = student.Adress, Email = student.Email};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öğrenci zaten mevcut ...");
        }

        
        [Fact]
        public void WhenValidInputsAreGiven_Student_ShouldBeCreated()
        {
            //arrange
            CreateStudentCommand command = new CreateStudentCommand(_context,_mapper);
            CreateStudentModel model = new CreateStudentModel() {Name="MATEMATİKS", SurName="MATEMATİKS", PhoneNumber="5321234567", Adress="BEŞİKTAŞ", Email="muhammetaygun@mail.com"};
            command.Model = model;
            
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var student = _context.Students.SingleOrDefault(student => student.Name == model.Name && student.SurName == model.SurName && student.PhoneNumber == model.PhoneNumber);
            student.Should().NotBeNull();
        }
    }
}
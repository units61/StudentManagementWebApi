
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using TestSetup;
using Xunit;

namespace Tests.TeacherManagementWebApi.UnitTests.Application.TeacherOperation.Command.DeleteTeacher
{
    public class DeleteTeacherCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
       

        public DeleteTeacherCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenTeacherIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.TeacherId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek öğrenci bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Teacher_ShouldBeCreated()
        {
            //arrange
           var teacher = new Teacher() {Name="ANILS", SurName="KOCAYİĞİTS", Qulification="MATEMATİKS"};
           _context.Add(teacher);
           _context.SaveChanges();

           DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
           command.TeacherId = teacher.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            teacher = _context.Teachers.SingleOrDefault(x=> x.Id == teacher.Id);
            teacher.Should().BeNull();
        }
    }

}
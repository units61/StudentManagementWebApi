
using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.Commands.DeleteStudent;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TestSetup;
using Xunit;

namespace Tests.StudentManagementWebApi.UnitTests.Application.StudentOperation.Command.DeleteStudent
{
    public class DeleteStudentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
       

        public DeleteStudentCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenStudentIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek öğrenci bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Student_ShouldBeCreated()
        {
            //arrange
           var student = new Student() {Name="MATEMATİKS", SurName="MATEMATİKS", PhoneNumber="5321234567", Adress="BEŞİKTAŞ", Email="muhammetaygun@mail.com"};
           _context.Add(student);
           _context.SaveChanges();

           DeleteStudentCommand command = new DeleteStudentCommand(_context);
           command.StudentId = student.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            student = _context.Students.SingleOrDefault(x=> x.Id == student.Id);
            student.Should().BeNull();
        }
    }

}

using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;


namespace StudentManagementWebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateStudentCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistStudentIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateStudentCommand command = new UpdateStudentCommand(_context);
            command.StudentId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek öğrenci bulunamadı ...");

        }

        [Fact]
        public void WhenGivenStudentIdinDB_Student_ShouldBeUpdate()
        {
            UpdateStudentCommand command = new UpdateStudentCommand(_context);

            UpdateStudentModel model = new UpdateStudentModel(){Name="MATEMATİKS", SurName="MATEMATİKS", PhoneNumber="5321234567", Adress="BEŞİKTAŞ", Email="muhammetaygun@mail.com"};            
            command.Model = model;
            command.StudentId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var student =_context.Students.SingleOrDefault(student=>student.Id == command.StudentId);
            student.Should().NotBeNull();
            
        }
    }

}
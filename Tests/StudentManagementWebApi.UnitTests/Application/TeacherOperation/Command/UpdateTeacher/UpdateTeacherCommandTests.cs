
using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;
using TestSetup;
using Xunit;


namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateTeacherCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistTeacherIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context);
            command.TeacherId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek öğretmen bulunamadı ...");

        }

        [Fact]
        public void WhenGivenTeacherIdinDB_Teacher_ShouldBeUpdate()
        {
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context);

            UpdateTeacherModel model = new UpdateTeacherModel(){Name="ANILS", SurName="KOCAYİĞİTS", Qulification="MATEMATİKS"};            
            command.Model = model;
            command.TeacherId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var teacher =_context.Teachers.SingleOrDefault(teacher=>teacher.Id == command.TeacherId);
            teacher.Should().NotBeNull();
            
        }
    }

}
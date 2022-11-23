
using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Commands.UpdateCourse;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;


namespace StudentManagementWebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateCourseCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistCourseIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateCourseCommand command = new UpdateCourseCommand(_context);
            command.CourseId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kurs bulunamadı ...");

        }

        [Fact]
        public void WhenGivenCourseIdinDB_Course_ShouldBeUpdate()
        {
            UpdateCourseCommand command = new UpdateCourseCommand(_context);

            UpdateCourseModel model = new UpdateCourseModel(){Name="WhenGivenBookIdinDB_Book_ShouldBeUpdate", Price=2000, TimeDuration="3 ay"};            
            command.Model = model;
            command.CourseId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var course =_context.Courses.SingleOrDefault(course=>course.Id == command.CourseId);
            course.Should().NotBeNull();
            
        }
    }

}
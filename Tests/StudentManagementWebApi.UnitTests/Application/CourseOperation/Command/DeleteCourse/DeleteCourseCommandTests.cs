


using AutoMapper;
using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Commands.DeleteCourse;
using StudentManagementWebApi.DBOperations;
using StudentManagementWebApi.Entities;
using TestSetup;
using Xunit;

namespace Tests.StudentManagementWebApi.UnitTests.Application.CourseOperation.Command.DeleteCourse
{
    public class DeleteCourseCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;
       

        public DeleteCourseCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Fact]
        public void WhenGivenCourseIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = 0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kurs bulunamadı ...");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Course_ShouldBeCreated()
        {
            //arrange
           var course = new Course() {Name = "WhenValidInputsAreGiven_Course_ShouldBeCreated", Price=100, TimeDuration="2 ay", TeacherId=1};
           _context.Add(course);
           _context.SaveChanges();

           DeleteCourseCommand command = new DeleteCourseCommand(_context);
           command.CourseId = course.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            course = _context.Courses.SingleOrDefault(x=> x.Id == course.Id);
            course.Should().BeNull();

        }
    }

}
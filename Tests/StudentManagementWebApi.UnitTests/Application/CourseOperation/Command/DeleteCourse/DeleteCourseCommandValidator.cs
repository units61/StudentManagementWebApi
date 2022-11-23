
using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Commands.DeleteCourse;
using TestSetup;
using Xunit;

namespace Tests.StudentManagementWebApi.UnitTests.Application.CourseOperation.Command.DeleteCourse
{
    public class DeleteCourseCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidCourseIdIsGiven_Validator_ShouldBeReturnErrors(int courseid)
        {
            //arrange
            DeleteCourseCommand command = new DeleteCourseCommand(null!);
            command.CourseId = courseid;
            
            //act
            DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int courseid)
        {
            DeleteCourseCommand command = new DeleteCourseCommand(null);
            command.CourseId = courseid;

            DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}
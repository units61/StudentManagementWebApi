using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Commands.CreateCourse;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using TestSetup;
using Xunit;

namespace Tests.StudentManagementWebApi.UnitTests.Application.CourseOperation.Command.CreateCourse
{
    public class CreateCourseCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(" ", 0, " ")]
        [InlineData(" ", -1, " " )]
        [InlineData("asd",0, "as" )]
        [InlineData("as", -10, "s" )]
        [InlineData("a", -20," a" )]
        [InlineData("aaa", -30, "asa")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, int price, string timeduration)
        {
            //arrange
            CreateCourseCommand command = new CreateCourseCommand(null, null);
            command.Model = new CreateCourseModel(){Name = name, Price = price, TimeDuration = timeduration};
            
            //act
            CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf ", 1000, "asdf")]
        [InlineData("asdf", 500, "asdf")]
        [InlineData("as  ", 2000, " as " )]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string name, int price, string timeduration)
        {
            //arrange
            CreateCourseCommand command = new CreateCourseCommand(null, null);
            command.Model = new CreateCourseModel(){Name = name, Price = price, TimeDuration = timeduration};
            
            //act
            CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}
using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Commands.UpdateCourse;
using StudentManagementWebApi.Application.CourseOperations.CourseModels;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;


namespace StudentManagementWebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateCourseCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0,"Lor",0,"asd")]
        [InlineData(0,"Lo ",-1," as")]
        [InlineData(1,"Lord",-10," ")]
        [InlineData(0,"Lor",-20,"ff")]
        [InlineData(-1,"Lord Of", -100, "asdf")]
        [InlineData(1," ", 0," ")]
        [InlineData(1,"",-300,"as")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int courseid, string name, int price, string timeduration)
        {
            //arrange
            UpdateCourseCommand command = new UpdateCourseCommand(null);
            command.Model = new UpdateCourseModel(){ Name=name, Price=price, TimeDuration=timeduration};
            command.CourseId=courseid;
            //act
            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"Lord Of The Rings",3,"asdf")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int courseid, string name, int price, string timeduration)
        {
            UpdateCourseCommand command = new UpdateCourseCommand(null);
            command.Model = new UpdateCourseModel()
            {
                Name = name,
                Price = price,
                TimeDuration = timeduration  
                              
            };
            command.CourseId=courseid;

            UpdateCourseCommandValidator validations=new UpdateCourseCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }

}
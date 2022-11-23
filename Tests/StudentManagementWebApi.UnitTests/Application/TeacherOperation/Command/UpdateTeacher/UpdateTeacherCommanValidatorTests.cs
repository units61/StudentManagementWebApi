using FluentAssertions;
using StudentManagementWebApi.DBOperations;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;
using TestSetup;
using Xunit;


namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateTeacherCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(-1,"as ", "as ", "as ")]
        [InlineData(1,"asd ", "ads ", "asd")]
        [InlineData(-2," ", " ", " ")]
        [InlineData(0," ds", "as ", " ds")]
        [InlineData(-200," asa", "dd", "asd ")]
        [InlineData(4," ", "asd", "as ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int teacherid, string name, string surname, string qulification)
        {
            //arrange
            UpdateTeacherCommand command = new UpdateTeacherCommand(null);
            command.Model = new UpdateTeacherModel(){ Name = name, SurName = surname, Qulification = qulification};
            command.TeacherId=teacherid;
            //act
            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"Lord Of The Rings","aasdd","asdf")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int teacherid, string name, string surname, string qulification)
        {
            UpdateTeacherCommand command = new UpdateTeacherCommand(null);
            command.Model = new UpdateTeacherModel()
            {
                Name = name,
                SurName = surname,
                Qulification = qulification          
            };
            command.TeacherId=teacherid;

            UpdateTeacherCommandValidator validations=new UpdateTeacherCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }

}
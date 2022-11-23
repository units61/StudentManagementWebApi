using FluentAssertions;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.CreateTeacher;
using TeacherManagementWebApi.Application.TeacherOperations.TeacherModels;
using TestSetup;
using Xunit;

namespace Tests.TeacherManagementWebApi.UnitTests.Application.TeacherOperation.Command.CreateTeacher
{
    public class CreateTeacherCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData("as ", "as ", "as ")]
        [InlineData("asd ", "ads ", "asd")]
        [InlineData(" ", " ", " ")]
        [InlineData(" ds", "as ", " ds")]
        [InlineData(" asa", "dd", "asd ")]
        [InlineData(" ", "asd", "as ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string qulification)
        {
            //arrange
            CreateTeacherCommand command = new CreateTeacherCommand(null, null);
            command.Model = new CreateTeacherModel(){Name = name, SurName = surname, Qulification = qulification};
            
            //act
            CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf ", "asdf ", "asdf ")]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string qulification)
        {
            //arrange
            CreateTeacherCommand command = new CreateTeacherCommand(null, null);
            command.Model = new CreateTeacherModel(){Name = name, SurName = surname, Qulification = qulification};
            
            //act
            CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0); 
        } 
    }
}
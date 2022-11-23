using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.Commands.CreateStudent;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using TestSetup;
using Xunit;

namespace Tests.StudentManagementWebApi.UnitTests.Application.StudentOperation.Command.CreateStudent
{
    public class CreateStudentCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData("as ", "as ", "as ", "as ", "as")]
        [InlineData("asd ", "ads ", "asd", "ads", "asd")]
        [InlineData(" ", " ", " ", " ", "")]
        [InlineData(" ds", "as ", " ds", " ss", "qw")]
        [InlineData(" asa", "dd", "asd ", "s ", "ss")]
        [InlineData(" ", "asd", "as ", "ss ", "aa")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string phonenumber, string adress, string email)
        {
            //arrange
            CreateStudentCommand command = new CreateStudentCommand(null, null);
            command.Model = new CreateStudentModel(){Name = name, SurName = surname, PhoneNumber = phonenumber, Adress = adress, Email = email};
            
            //act
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }


        [Theory]
        [InlineData("asdf ", "asdf ", "asdf ", "asdf ", "asdf")]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string phonenumber, string adress, string email)
        {
            //arrange
            CreateStudentCommand command = new CreateStudentCommand(null, null);
            command.Model = new CreateStudentModel(){Name = name, SurName = surname, PhoneNumber = phonenumber, Adress = adress, Email = email};
            
            //act
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0); 
        } 
    }
}
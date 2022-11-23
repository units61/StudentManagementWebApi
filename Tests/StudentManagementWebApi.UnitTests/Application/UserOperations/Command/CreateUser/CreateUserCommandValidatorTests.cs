using AutoMapper;
using FluentAssertions;
using TestSetup;
using Xunit;
using static StudentManagementWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace StudentManagementWebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(" ", " "," ", " ")]
        [InlineData("asd ", " ad "," asd", "ad ")]
        [InlineData(" ", " ada "," a", "a")]
        [InlineData("asdf", "","", "")]
        [InlineData("f ", "","", "ffff")]
        [InlineData("fff", "aaa","ddd", "ccc")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password)
        {
            //arrange
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel(){Name = name, Surname = surname, Email = email, Password = password};
            
            //act
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData("asdf", "asdf","asdf", "123456")]
        [InlineData("asd ", " sdf","a df", "123456789")]
        [InlineData("  df", "asdf","asdf", "132456798132")]
        [InlineData(" sdf", "____","sa  ", "123456789132123")]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password)
        {
            //arrange
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel(){Name = name, Surname = surname, Email = email, Password = password};
            
            //act
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
           
        } 
    }
}
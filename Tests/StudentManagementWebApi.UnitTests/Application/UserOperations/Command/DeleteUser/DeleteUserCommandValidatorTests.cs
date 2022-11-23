using AutoMapper;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidUserIdIsGiven_Validator_ShouldBeReturnErrors(int userid)
        {
            //arrange
            DeleteUserCommand command = new DeleteUserCommand(null!);
            command.UserId = userid;
            
            //act
            DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidUserIdisGiven_Validator_ShouldNotBeReturnError(int userid)
        {
            DeleteUserCommand command = new DeleteUserCommand(null!);
            command.UserId = userid;

            DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}
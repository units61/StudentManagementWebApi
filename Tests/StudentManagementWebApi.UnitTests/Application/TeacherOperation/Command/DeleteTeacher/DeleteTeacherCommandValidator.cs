
using FluentAssertions;
using TeacherManagementWebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using TestSetup;
using Xunit;

namespace Tests.TeacherManagementWebApi.UnitTests.Application.TeacherOperation.Command.DeleteTeacher
{
    public class DeleteTeacherCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidTeacherIdIsGiven_Validator_ShouldBeReturnErrors(int teacherid)
        {
            //arrange
            DeleteTeacherCommand command = new DeleteTeacherCommand(null!);
            command.TeacherId = teacherid;
            
            //act
            DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int teacherid)
        {
            DeleteTeacherCommand command = new DeleteTeacherCommand(null);
            command.TeacherId = teacherid;

            DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}
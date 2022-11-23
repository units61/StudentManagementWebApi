
using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.Commands.DeleteStudent;
using TestSetup;
using Xunit;

namespace Tests.StudentManagementWebApi.UnitTests.Application.StudentOperation.Command.DeleteStudent
{
    public class DeleteStudentCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidStudentIdIsGiven_Validator_ShouldBeReturnErrors(int studentid)
        {
            //arrange
            DeleteStudentCommand command = new DeleteStudentCommand(null!);
            command.StudentId = studentid;
            
            //act
            DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidBookIdisGiven_Validator_ShouldNotBeReturnError(int studentid)
        {
            DeleteStudentCommand command = new DeleteStudentCommand(null);
            command.StudentId = studentid;

            DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}
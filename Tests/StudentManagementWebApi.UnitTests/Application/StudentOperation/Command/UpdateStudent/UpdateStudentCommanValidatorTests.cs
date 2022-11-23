using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.StudentModels;
using StudentManagementWebApi.DBOperations;
using TestSetup;
using Xunit;


namespace StudentManagementWebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentManagementDbContext _context;

        public UpdateStudentCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0,"Lor","0","asd","a ","d ")]
        [InlineData(-1,"Lor","0","asd"," "," ")]
        [InlineData(-200,"Lor","0","asd"," "," ")]
        [InlineData(0,"Lord","0","asd"," "," ")]
        [InlineData(0,"Lor","0","asd"," "," as")]
        [InlineData(0,"Lor","0","asd","as "," ")]
        [InlineData(0,"Lor","0","asd","d ","e ")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int studentid, string name, string surname, string phonenumber, string adress, string email)
        {
            //arrange
            UpdateStudentCommand command = new UpdateStudentCommand(null);
            command.Model = new UpdateStudentModel(){ Name = name, SurName = surname, PhoneNumber = phonenumber, Adress = adress, Email = email};
            command.StudentId=studentid;
            //act
            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [InlineData(1,"Lord Of The Rings","aasdd","asdf","asdasdas","asdasdasd")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int studentid, string name, string surname, string phonenumber, string adress, string email)
        {
            UpdateStudentCommand command = new UpdateStudentCommand(null);
            command.Model = new UpdateStudentModel()
            {
                Name = name,
                SurName = surname,
                PhoneNumber = phonenumber,
                Adress = adress,
                Email = email             
            };
            command.StudentId=studentid;

            UpdateStudentCommandValidator validations=new UpdateStudentCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }

}
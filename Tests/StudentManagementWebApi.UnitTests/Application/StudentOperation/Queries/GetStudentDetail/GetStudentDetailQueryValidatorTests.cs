using FluentAssertions;
using StudentManagementWebApi.Application.StudentOperations.Queries.GetDetailStudent;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidStudentidIsGiven_Validator_ShouldBeReturnErrors(int studentid)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(null,null);
            query.StudentId=studentid;

            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidStudentidIsGiven_Validator_ShouldNotBeReturnErrors(int studentid)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(null,null);
            query.StudentId=studentid;

            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}
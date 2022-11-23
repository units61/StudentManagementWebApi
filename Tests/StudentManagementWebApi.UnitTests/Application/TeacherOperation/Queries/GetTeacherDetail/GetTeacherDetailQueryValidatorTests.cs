using FluentAssertions;
using TeacherManagementWebApi.Application.TeacherOperations.Queries.GetDetailTeacher;
using TestSetup;
using Xunit;

namespace TeacherManagementWebApi.Application.TeacherOperations.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidTeacheridIsGiven_Validator_ShouldBeReturnErrors(int teacherid)
        {
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(null,null);
            query.TeacherId=teacherid;

            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidTeacheridIsGiven_Validator_ShouldNotBeReturnErrors(int teacherid)
        {
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(null,null);
            query.TeacherId=teacherid;

            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}
using FluentAssertions;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.UserOperations.Queries.GetUserDetail
{
    public class GetUserDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidUseridIsGiven_Validator_ShouldBeReturnErrors(int userid)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(null,null);
            query.UserId=userid;

            GetUserDetailQeuryValidator validator = new GetUserDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidAuthoridIsGiven_Validator_ShouldNotBeReturnErrors(int userid)
        {
            GetUserDetailQuery query = new GetUserDetailQuery(null,null);
            query.UserId=userid;

            GetUserDetailQeuryValidator validator = new GetUserDetailQeuryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}
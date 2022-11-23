using FluentAssertions;
using StudentManagementWebApi.Application.CourseOperations.Queries.GetDetailCourse;
using TestSetup;
using Xunit;

namespace StudentManagementWebApi.Application.CourseOperations.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidCourseidIsGiven_Validator_ShouldBeReturnErrors(int courseid)
        {
            GetCourseDetailQuery query = new GetCourseDetailQuery(null,null);
            query.CourseId=courseid;

            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidCourseidIsGiven_Validator_ShouldNotBeReturnErrors(int courseid)
        {
            GetCourseDetailQuery query = new GetCourseDetailQuery(null,null);
            query.CourseId=courseid;

            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}
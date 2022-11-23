using FluentValidation;

namespace StudentManagementWebApi.Application.CourseOperations.Queries.GetDetailCourse
{
   public class GetCourseDetailQueryValidator : AbstractValidator<GetCourseDetailQuery>
   {
        public GetCourseDetailQueryValidator()
        {
            RuleFor(query => query.CourseId).GreaterThan(0);
        }
   }
}
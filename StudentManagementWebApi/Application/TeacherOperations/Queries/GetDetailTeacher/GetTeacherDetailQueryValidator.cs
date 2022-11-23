using FluentValidation;

namespace TeacherManagementWebApi.Application.TeacherOperations.Queries.GetDetailTeacher
{
   public class GetTeacherDetailQueryValidator : AbstractValidator<GetTeacherDetailQuery>
   {
        public GetTeacherDetailQueryValidator()
        {
            RuleFor(query => query.TeacherId).GreaterThan(0);
        }
   }
}
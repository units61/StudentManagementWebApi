using FluentValidation;

namespace StudentManagementWebApi.Application.StudentOperations.Queries.GetDetailStudent
{
   public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
   {
        public GetStudentDetailQueryValidator()
        {
            RuleFor(query => query.StudentId).GreaterThan(0);
        }
   }
}
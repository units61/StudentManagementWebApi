using FluentValidation;

namespace StudentManagementWebApi.Application.UserOperations.Queries.GetUserDetail
{
   public class GetUserDetailQeuryValidator : AbstractValidator<GetUserDetailQuery>
   {
        public GetUserDetailQeuryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
   }
}
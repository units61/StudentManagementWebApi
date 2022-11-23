using FluentValidation;

namespace StudentManagementWebApi.Application.UserOperations.Commands.UpdateUser
{
   public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
   {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
        }
   }
}
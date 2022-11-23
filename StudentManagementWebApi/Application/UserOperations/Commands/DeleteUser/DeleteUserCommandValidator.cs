using FluentValidation;

namespace StudentManagementWebApi.Application.UserOperations.Commands.DeleteUser
{
   public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
   {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThan(0);
        }
   }
}
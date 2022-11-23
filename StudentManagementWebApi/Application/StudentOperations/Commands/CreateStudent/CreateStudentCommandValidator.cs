using FluentValidation;

namespace StudentManagementWebApi.Application.StudentOperations.Commands.CreateStudent
{
   public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
   {
        public CreateStudentCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PhoneNumber).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Adress).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);
        }
   }
}
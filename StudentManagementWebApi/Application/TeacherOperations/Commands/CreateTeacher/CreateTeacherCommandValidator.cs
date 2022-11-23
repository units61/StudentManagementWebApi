using FluentValidation;

namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.CreateTeacher
{
   public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
   {
        public CreateTeacherCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Qulification).NotEmpty().MinimumLength(4);
           
        }
   }
}
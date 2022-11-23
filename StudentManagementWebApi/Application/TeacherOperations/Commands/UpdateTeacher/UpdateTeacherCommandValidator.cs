using FluentValidation;

namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(command => command.TeacherId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Qulification).NotEmpty().MinimumLength(4);
        }
    }
}
using FluentValidation;

namespace TeacherManagementWebApi.Application.TeacherOperations.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandValidator : AbstractValidator<DeleteTeacherCommand>
   {
        public DeleteTeacherCommandValidator()
        {
            RuleFor(command => command.TeacherId).GreaterThan(0);
        }
   }
}
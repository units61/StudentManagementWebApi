using FluentValidation;

namespace StudentManagementWebApi.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
   {
        public DeleteStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
        }
   }
}
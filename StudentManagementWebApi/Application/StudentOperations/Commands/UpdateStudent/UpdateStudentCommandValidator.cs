using FluentValidation;

namespace StudentManagementWebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PhoneNumber).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Adress).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);        
        }
    }
}
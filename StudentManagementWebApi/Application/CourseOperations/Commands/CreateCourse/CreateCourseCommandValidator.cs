using FluentValidation;

namespace StudentManagementWebApi.Application.CourseOperations.Commands.CreateCourse
{
   public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
   {
        public CreateCourseCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.TimeDuration).NotEmpty().MinimumLength(4);
        }
   }
}
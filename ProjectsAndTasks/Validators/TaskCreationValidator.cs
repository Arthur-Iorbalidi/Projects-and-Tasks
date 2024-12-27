using FluentValidation;
using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Validators
{
	public class TaskCreationValidator : AbstractValidator<TaskCreationDto>
	{
		public TaskCreationValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty")
				.MaximumLength(100)
				.WithMessage("Max length of {PropertyName} is 100");
			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty");
			RuleFor(x => x.Priority)
				.IsInEnum().WithMessage("Invalid priority option.");
		}
	}
}

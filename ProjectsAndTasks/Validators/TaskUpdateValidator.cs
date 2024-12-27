using FluentValidation;
using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Validators
{
	public class TaskUpdateValidator : AbstractValidator<TaskUpdateDto>
	{
		public TaskUpdateValidator()
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
			When(dto => dto.isCompleted, () =>
			{
				RuleFor(dto => dto.CompletionDate)
					.NotNull().WithMessage("{PropertyName} should be specified");
			});

			When(dto => !dto.isCompleted, () =>
			{
				RuleFor(dto => dto.CompletionDate)
					.Null().WithMessage("{PropertyName} may be null");
			});
		}
	}
}

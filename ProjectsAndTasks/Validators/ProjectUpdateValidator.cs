using FluentValidation;
using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Validators
{
	public class ProjectUpdateValidator : AbstractValidator<ProjectUpdateDto>
	{
		public ProjectUpdateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty")
				.MaximumLength(100)
				.WithMessage("Max length of {PropertyName} is 100");
			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty");
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

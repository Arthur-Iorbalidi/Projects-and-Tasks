using FluentValidation;
using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Validators
{
	public class ProjectCreationValidator : AbstractValidator<ProjectCreationDto>
	{
		public ProjectCreationValidator() 
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty")
				.MaximumLength(100)
				.WithMessage("Max length of {PropertyName} is 100");
			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty");
		}
	}
}

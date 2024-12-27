using FluentValidation;
using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Validators
{
	public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
	{
		public UserUpdateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty");
			RuleFor(x => x.Surname)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty");
			RuleFor(x => x.Email)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty")
				.EmailAddress()
				.WithMessage("Incorrect email");
			RuleFor(x => x.Password)
				.NotEmpty()
				.WithMessage("{PropertyName} cannot be empty")
				.Custom((password, context) =>
				{
					if (password.Length < 8)
					{
						context.AddFailure("Password should contain at least 8 symbols");
					}
				})
				.Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^A-Za-z0-9\s]).+$")
				.WithMessage("{PropertyName} should contain numbers, letters and special symbols");
		}
	}
}

using ProjectsAndTasks.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectsAndTasks.DTO
{
	public record UserDto(int Id, string Name, string Surname, string Email);

	public record UserCreationDto
	{
		public string Name { get; init; }

		public string Surname { get; init; }

		public string Email { get; init; }

		public string Password { get; init; }
	}

	public record UserUpdateDto
	{
		public string Name { get; init; }

		public string Surname { get; init; }

		public string Email { get; init; }

		public string Password { get; init; }
	}
}

using ProjectsAndTasks.Enums;

namespace ProjectsAndTasks.DTO
{
	public record TaskDto(int Id, string Name, string Description, bool isCompleted, DateTime CreationDate, DateTime? CompletionDate, PriorityOprtions Priority);

	public record TaskCreationDto
	{
		public string Name { get; init; }
		public string Description { get; init; }

		public PriorityOprtions Priority { get; init; }
	}

	public record TaskUpdateDto
	{
		public string Name { get; init; }
		public string Description { get; init; }

		public bool isCompleted { get; init; }

		public DateTime? CompletionDate { get; init; }

		public PriorityOprtions Priority { get; init; }
	}
}

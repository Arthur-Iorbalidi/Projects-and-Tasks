namespace ProjectsAndTasks.DTO
{
	public record ProjectDto(int Id, string Name, string Description, bool isCompleted, DateTime CreationDate, DateTime? CompletionDate);

	public record ProjectCreationDto 
	{
        public string Name { get; init; }
		public string Description { get; init; }
    }

	public record ProjectUpdateDto
	{
		public string Name { get; init; }
		public string Description { get; init; }

		public bool isCompleted { get; init; }

		public DateTime? CompletionDate { get; init; }
	}
}

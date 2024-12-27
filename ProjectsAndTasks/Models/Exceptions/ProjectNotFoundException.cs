namespace ProjectsAndTasks.Models.Exceptions
{
	public sealed class ProjectNotFoundException : NotFoundException
	{
		public ProjectNotFoundException(int id)
			: base($"Project with id: {id} not found")
		{

		}
	}
}

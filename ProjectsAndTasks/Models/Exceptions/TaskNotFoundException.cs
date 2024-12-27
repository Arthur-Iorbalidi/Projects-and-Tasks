namespace ProjectsAndTasks.Models.Exceptions
{
	public sealed class TaskNotFoundException : NotFoundException
	{
		public TaskNotFoundException(int id)
			: base($"Task with id: {id} not found")
		{

		}
	}
}

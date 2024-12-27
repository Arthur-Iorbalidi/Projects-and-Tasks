namespace ProjectsAndTasks.Models.Exceptions
{
	public sealed class UserTaskNotFoundException : NotFoundException
	{
		public UserTaskNotFoundException(int taskId, int userId)
			: base($"Task with id: {taskId} not found for User with id: {userId}")
		{

		}
	}
}

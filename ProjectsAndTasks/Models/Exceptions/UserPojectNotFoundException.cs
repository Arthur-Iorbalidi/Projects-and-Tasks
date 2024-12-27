namespace ProjectsAndTasks.Models.Exceptions
{
	public sealed class UserProjectNotFoundException : NotFoundException
	{
		public UserProjectNotFoundException(int projectId, int userId)
			: base($"Project with id: {projectId} not found for User with id: {userId}")
		{

		}
	}
}

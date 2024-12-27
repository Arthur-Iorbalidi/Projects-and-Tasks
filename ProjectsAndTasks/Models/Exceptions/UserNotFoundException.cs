namespace ProjectsAndTasks.Models.Exceptions
{
	public sealed class UserNotFoundException : NotFoundException
	{
		public UserNotFoundException(int id)
			: base($"User with id: {id} not found")
		{

		}
	}
}

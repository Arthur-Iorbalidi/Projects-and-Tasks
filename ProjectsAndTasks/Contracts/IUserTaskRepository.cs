using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Contracts
{
	public interface IUserTaskRepository
	{
		UserTaskDto GetUserTask(int userId, int taskId);

		UserTaskDto CreateUserTask(int userId, int taskId, bool trackChanges);

		void DeleteUserTask(int userId, int taskId, bool trackChanges);
	}
}

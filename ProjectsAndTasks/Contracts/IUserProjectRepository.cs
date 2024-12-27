using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Contracts
{
	public interface IUserProjectRepository
	{
		UserProjectDto GetUserProject(int userId, int projectId);

		UserProjectDto CreateUserProject(int userId, int projectId, bool trackChanges);

		void DeleteUserProject(int userId, int projectId, bool trackChanges);
	}
}

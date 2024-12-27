using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Contracts
{
	public interface IProjectRepository
	{
		IEnumerable<ProjectDto> GetAllProjects(bool trackChanges);

		ProjectDto GetProject(int id, bool trackChanges);

		ProjectDto CreateProject(ProjectCreationDto project);

		void DeleteProject(int projectId, bool trackChanges);

		void UpdateProject(int taskId, ProjectUpdateDto project, bool trackChanges);
	}
}

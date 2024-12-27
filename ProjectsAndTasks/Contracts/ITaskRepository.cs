using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Contracts
{
	public interface ITaskRepository
	{
		IEnumerable<TaskDto> GetAllTasks(bool trackChanges);

		TaskDto GetTask(int id, bool trackChanges);

		TaskDto CreateTask(int projectId, TaskCreationDto task, bool trackChanges);

		void DeleteTask(int taskId, bool trackChanges);

		void UpdateTask(int taskId, TaskUpdateDto task, bool trackChanges);
	}
}

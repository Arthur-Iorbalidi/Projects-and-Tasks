using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Models.Exceptions;
using System.Threading.Tasks;

namespace ProjectsAndTasks.Repository
{
	public class TaskRepository : RepositoryBase<Models.Task>, ITaskRepository
	{
        private readonly IMapper _mapper;
        public TaskRepository(RepositoryContext context, IMapper mapper) : base(context)
		{
            _mapper = mapper;
        }

		public IEnumerable<TaskDto> GetAllTasks(bool trackChanges)
		{
			var tasks = FindAll(trackChanges).OrderBy(g => g.Id).ToList();

			var tasksDto = tasks.Select(g => _mapper.Map<TaskDto>(g)).ToList();

			return tasksDto;
		}

		public TaskDto GetTask(int id, bool trackChanges)
		{
			var task = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

			if (task == null)
			{
				throw new TaskNotFoundException(id);
			}

			var taskDto = _mapper.Map<TaskDto>(task);
			return taskDto;
		}

		public TaskDto CreateTask(int projectId, TaskCreationDto taskCreationDto, bool trackChanges)
		{
			var projectToCheck = _context.Set<Project>()
				.Where(g => g.Id.Equals(projectId))
				.AsNoTracking()
				.SingleOrDefault();

			if (projectToCheck == null) 
			{
				throw new ProjectNotFoundException(projectId);
			}

			var taskEntity = _mapper.Map<Models.Task>(taskCreationDto);
			taskEntity.ProjectId = projectId;

			Create(taskEntity);

			var taskToReturn = _mapper.Map<TaskDto>(taskEntity);

			return taskToReturn;
		}

		public void DeleteTask(int taskId, bool trackChanges)
		{
			var task = _context.Set<Models.Task>()
				.Where(u => u.Id == taskId)
				.AsNoTracking()
				.FirstOrDefault();

			if (task == null)
			{
				throw new TaskNotFoundException(taskId);
			}

			Delete(task);

			_context.SaveChanges();
		}

		public void UpdateTask(int taskId, TaskUpdateDto taskDto, bool trackChanges)
		{
			var task = FindByCondition(t => t.Id.Equals(taskId), trackChanges)
				.SingleOrDefault();

			if (task == null)
			{
				throw new TaskNotFoundException(taskId);
			}

			_mapper.Map(taskDto, task);
			_context.SaveChanges();
		}
	}
}

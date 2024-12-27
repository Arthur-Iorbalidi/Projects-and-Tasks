using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Models.Exceptions;

namespace ProjectsAndTasks.Repository
{
	public class UserTaskRepository : RepositoryBase<UserTask>, IUserTaskRepository
	{
		private readonly IMapper _mapper;
		public UserTaskRepository(RepositoryContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public UserTaskDto GetUserTask(int userId, int taskId)
		{
			var userTaskEntity = _context.Set<UserTask>()
				.Where(ut => ut.UserId == userId && ut.TaskId == taskId)
				.AsNoTracking()
				.SingleOrDefault();

			if (userTaskEntity == null)
			{
				throw new UserTaskNotFoundException(taskId, userId);
			}

			var userTaskToReturn = _mapper.Map<UserTaskDto>(userTaskEntity);
			return userTaskToReturn;
		}

		public UserTaskDto CreateUserTask(int userId, int taskId, bool trackChanges)
		{
			var userToCheck = _context.Set<User>()
				.Where(g => g.Id.Equals(userId))
				.AsNoTracking()
				.SingleOrDefault();

			if (userToCheck == null)
			{
				throw new UserNotFoundException(userId);
			}

			var taskToCheck = _context.Set<Models.Task>()
				.Where(g => g.Id.Equals(taskId))
				.AsNoTracking()
				.SingleOrDefault();

			if (taskToCheck == null)
			{
				throw new TaskNotFoundException(taskId);
			}

			var userTaskEntity = new UserTask();
			userTaskEntity.UserId = userId;
			userTaskEntity.TaskId = taskId;

			Create(userTaskEntity);

			var userTaskToReturn = _mapper.Map<UserTaskDto>(userTaskEntity);

			return userTaskToReturn;
		}

		public void DeleteUserTask(int userId, int taskId, bool trackChanges)
		{
			var userToCheck = _context.Set<User>()
				.Where(g => g.Id.Equals(userId))
				.AsNoTracking()
				.SingleOrDefault();

			if (userToCheck == null)
			{
				throw new UserNotFoundException(userId);
			}

			var taskToCheck = _context.Set<Models.Task>()
				.Where(g => g.Id.Equals(taskId))
				.AsNoTracking()
				.SingleOrDefault();

			if (taskToCheck == null)
			{
				throw new TaskNotFoundException(taskId);
			}

			var userTask = FindByCondition(ut => ut.UserId.Equals(userId) && ut.TaskId.Equals(taskId), trackChanges)
				.SingleOrDefault();

			if (userTask == null)
			{
				throw new UserTaskNotFoundException(taskId, userId);
			}

			Delete(userTask);

			_context.SaveChanges();
		}
	}
}

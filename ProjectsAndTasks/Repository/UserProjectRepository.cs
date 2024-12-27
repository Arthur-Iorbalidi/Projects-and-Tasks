using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Models.Exceptions;

namespace ProjectsAndTasks.Repository
{
	public class UserProjectRepository : RepositoryBase<UserProject>, IUserProjectRepository
	{
		private readonly IMapper _mapper;
		public UserProjectRepository(RepositoryContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public UserProjectDto GetUserProject(int userId, int projectId)
		{
			var userProjectEntity = _context.Set<UserProject>()
				.Where(ut => ut.UserId == userId && ut.ProjectId == projectId)
				.AsNoTracking()
				.SingleOrDefault();

			if (userProjectEntity == null)
			{
				throw new UserProjectNotFoundException(projectId, userId);
			}

			var userProjectToReturn = _mapper.Map<UserProjectDto>(userProjectEntity);
			return userProjectToReturn;
		}

		public UserProjectDto CreateUserProject(int userId, int projectId, bool trackChanges)
		{
			var userToCheck = _context.Set<User>()
				.Where(g => g.Id.Equals(userId))
				.AsNoTracking()
				.SingleOrDefault();

			if (userToCheck == null)
			{
				throw new UserNotFoundException(userId);
			}

			var projectToCheck = _context.Set<Project>()
				.Where(g => g.Id.Equals(projectId))
				.AsNoTracking()
				.SingleOrDefault();

			if (projectToCheck == null)
			{
				throw new ProjectNotFoundException(projectId);
			}

			var userProjectEntity = new UserProject();
			userProjectEntity.UserId = userId;
			userProjectEntity.ProjectId = projectId;

			Create(userProjectEntity);

			var userTaskToReturn = _mapper.Map<UserProjectDto>(userProjectEntity);

			return userTaskToReturn;
		}

		public void DeleteUserProject(int userId, int projectId, bool trackChanges)
		{
			var userToCheck = _context.Set<User>()
				.Where(g => g.Id.Equals(userId))
				.AsNoTracking()
				.SingleOrDefault();

			if (userToCheck == null)
			{
				throw new UserNotFoundException(userId);
			}

			var projectToCheck = _context.Set<Project>()
				.Where(g => g.Id.Equals(projectId))
				.AsNoTracking()
				.SingleOrDefault();

			if (projectToCheck == null)
			{
				throw new ProjectNotFoundException(projectId);
			}

			var userProject = FindByCondition(up => up.UserId.Equals(userId) && up.ProjectId.Equals(projectId), trackChanges)
				.SingleOrDefault();

			if (userProject == null)
			{
				throw new UserProjectNotFoundException(projectId, userId);
			}

			Delete(userProject);

			_context.SaveChanges();
		}
	}
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Models.Exceptions;

namespace ProjectsAndTasks.Repository
{
	public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
	{
		private readonly IMapper _mapper;
		public ProjectRepository(RepositoryContext context, IMapper mapper) : base(context) 
		{
			_mapper = mapper;
		}

		public IEnumerable<ProjectDto> GetAllProjects(bool trackChanges)
		{
			var projects = FindAll(trackChanges).OrderBy(g => g.Id).ToList();

			var projectsDto = projects.Select(g => _mapper.Map<ProjectDto>(g)).ToList();

			return projectsDto;
		}

		public ProjectDto GetProject(int id, bool trackChanges)
		{
			var project = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

			if (project == null)
			{
				throw new ProjectNotFoundException(id);
			}

			var projectDto = _mapper.Map<ProjectDto>(project);

			return projectDto;
		}

		public ProjectDto CreateProject(ProjectCreationDto projectCreationDto)
		{
			var project = _mapper.Map<Project>(projectCreationDto);

			Create(project);

			var projectToReturn = _mapper.Map<ProjectDto>(project);

			return projectToReturn;
		}

		public void DeleteProject(int projectId, bool trackChanges)
		{
			var project = _context.Set<Project>()
				.Where(p => p.Id == projectId)
				.AsNoTracking()
				.FirstOrDefault();

			if (project == null)
			{
				throw new ProjectNotFoundException(projectId);
			}

			Delete(project);

			_context.SaveChanges();
		}

		public void UpdateProject(int projectId, ProjectUpdateDto projectDto, bool trackChanges)
		{
			var project = FindByCondition(p => p.Id.Equals(projectId), trackChanges)
				.SingleOrDefault();

			if (project == null)
			{
				throw new ProjectNotFoundException(projectId);
			}

			_mapper.Map(projectDto, project);
			_context.SaveChanges();
		}
	}
}

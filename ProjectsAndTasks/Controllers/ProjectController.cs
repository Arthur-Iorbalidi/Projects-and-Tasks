using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Repository;

namespace ProjectsAndTasks.Controllers
{
	[ApiController]
	[Route("api/projects")]
	public class ProjectController : ControllerBase
	{
		public readonly IProjectRepository _projectRepository;
		private readonly IValidator<ProjectCreationDto> _postProjectValidator;
		private readonly IValidator<ProjectUpdateDto> _putProjectValidator;

		public ProjectController(IProjectRepository projectRepository, IValidator<ProjectCreationDto> postProjectValidator, IValidator<ProjectUpdateDto> putProjectValidator)
		{
			_projectRepository = projectRepository;
			_postProjectValidator = postProjectValidator;
			_putProjectValidator = putProjectValidator;
		}

		[HttpGet]
		public IActionResult GetAllProjects()
		{
			var projects = _projectRepository.GetAllProjects(trackChanges: false);

			return Ok(projects);
		}

		[HttpGet("{id:int}", Name = "GetProject")]
		public IActionResult GetProject(int id)
		{
			var project = _projectRepository.GetProject(id, trackChanges: false);

			return Ok(project);
		}

		[HttpPost]
		public IActionResult CreateProject([FromBody] ProjectCreationDto projectCreationDto)
		{
			if (projectCreationDto == null)
			{
				return BadRequest("projectCreationDto object is null");
			}

			_postProjectValidator.ValidateAndThrow(projectCreationDto);

			var createdProject = _projectRepository.CreateProject(projectCreationDto);

			return CreatedAtRoute("GetProject", new { id = createdProject.Id }, createdProject);
		}

		[HttpDelete("{projectId:int}")]
		public NoContentResult DeleteUser(int projectId)
		{
			_projectRepository.DeleteProject(projectId, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{projectId:int}")]
		public IActionResult UpdateProject(int projectId, [FromBody] ProjectUpdateDto projectUpdateDto)
		{
			if (projectUpdateDto == null)
			{
				return BadRequest();
			}

			_putProjectValidator.ValidateAndThrow(projectUpdateDto);

			_projectRepository.UpdateProject(projectId, projectUpdateDto, trackChanges: true);

			return NoContent();
		}
	}
}

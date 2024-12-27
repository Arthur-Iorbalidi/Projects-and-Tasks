using Microsoft.AspNetCore.Mvc;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Repository;

namespace ProjectsAndTasks.Controllers
{
	[ApiController]
	[Route("api/users/{userId}/projects")]
	public class UserProjectController : ControllerBase
	{
		public readonly IUserProjectRepository _userProjectRepository;

		public UserProjectController(IUserProjectRepository userProjectRepository)
		{
			_userProjectRepository = userProjectRepository;
		}

		[HttpGet("{projectId}")]
		public IActionResult GetUserProject(int userId, int projectId)
		{
			var userTask = _userProjectRepository.GetUserProject(userId, projectId);
			if (userTask == null)
			{
				return NotFound();
			}

			return Ok(userTask);
		}


		[HttpPost]
		public IActionResult CreateUserProject(int userId, int projectId)
		{
			var userTask = _userProjectRepository.CreateUserProject(userId, projectId, false);

			return CreatedAtAction(nameof(GetUserProject), new { userId = userId, projectId = projectId }, userTask);
		}

		[HttpDelete("{projectId:int}")]
		public NoContentResult DeleteUserProject(int userId, int projectId)
		{
			_userProjectRepository.DeleteUserProject(userId, projectId, false);

			return NoContent();
		}
	}
}

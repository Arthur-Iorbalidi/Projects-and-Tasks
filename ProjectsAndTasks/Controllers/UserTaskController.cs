using Microsoft.AspNetCore.Mvc;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;

namespace ProjectsAndTasks.Controllers
{
	[ApiController]
	[Route("api/users/{userId}/tasks")]
	public class UserTaskController : ControllerBase
	{
		public readonly IUserTaskRepository _userTaskRepository;

		public UserTaskController(IUserTaskRepository userTaskRepository)
		{
			_userTaskRepository = userTaskRepository;
		}

		[HttpGet("{taskId}")]
		public IActionResult GetUserTask(int userId, int taskId)
		{
			var userTask = _userTaskRepository.GetUserTask(userId, taskId);
			if (userTask == null)
			{
				return NotFound();
			}

			return Ok(userTask);
		}


		[HttpPost]
		public IActionResult CreateUserTask(int userId, int taskId)
		{
			var userTask = _userTaskRepository.CreateUserTask(userId, taskId, false);

			return CreatedAtAction(nameof(GetUserTask), new { userId = userId, taskId = taskId }, userTask);
		}

		[HttpDelete("{taskId:int}")]
		public NoContentResult DeleteUserTask(int userId, int taskId)
		{
			_userTaskRepository.DeleteUserTask(userId, taskId, false);

			return NoContent();
		}
	}
}

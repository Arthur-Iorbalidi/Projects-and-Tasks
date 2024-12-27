using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Repository;

namespace ProjectsAndTasks.Controllers
{
	[ApiController]
	[Route("api/tasks")]
	public class TaskController : ControllerBase
	{
		public readonly ITaskRepository _taskRepository;
		private readonly IValidator<TaskCreationDto> _postTaskValidator;
		private readonly IValidator<TaskUpdateDto> _putTaskValidator;

		public TaskController(ITaskRepository taskRepository, IValidator<TaskCreationDto> postTaskValidator, IValidator<TaskUpdateDto> putTaskValidator)
		{
			_taskRepository = taskRepository;
			_postTaskValidator = postTaskValidator;
			_putTaskValidator = putTaskValidator;
		}

		[HttpGet]
		public IActionResult GetAllTasks()
		{
			var tasks = _taskRepository.GetAllTasks(trackChanges: false);

			return Ok(tasks);
		}

		[HttpGet("{id:int}", Name = "GetTask")]
		public IActionResult GetTask(int id)
		{
			var task = _taskRepository.GetTask(id, trackChanges: false);

			return Ok(task);
		}

		[HttpPost]
		public IActionResult CreateTask(int projectId, [FromBody] TaskCreationDto taskCreationDto)
		{
			if (taskCreationDto == null)
			{
				return BadRequest("TaskCreationDto object is null");
			}

			_postTaskValidator.ValidateAndThrow(taskCreationDto);

			var createdTask = _taskRepository.CreateTask(projectId, taskCreationDto, false);

			return CreatedAtRoute("GetTask", new { id = createdTask.Id }, createdTask);
		}

		[HttpDelete("{taskId:int}")]
		public NoContentResult DeleteUser(int taskId)
		{
			_taskRepository.DeleteTask(taskId, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{taskId:int}")]
		public IActionResult UpdateTask(int taskId, [FromBody] TaskUpdateDto taskUpdateDto)
		{
			if (taskUpdateDto == null)
			{
				return BadRequest();
			}

			_putTaskValidator.ValidateAndThrow(taskUpdateDto);

			_taskRepository.UpdateTask(taskId, taskUpdateDto, trackChanges: true);

			return NoContent();
		}
	}
}

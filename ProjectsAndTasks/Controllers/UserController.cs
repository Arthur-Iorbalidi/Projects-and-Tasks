using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Extensions;
using ProjectsAndTasks.Repository;

namespace ProjectsAndTasks.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{
		public readonly IUserRepository _userRepository;
		private readonly IValidator<UserCreationDto> _postUserValidator;
		private readonly IValidator<UserUpdateDto> _putUserValidator;

		public UserController(IUserRepository userRepository, IValidator<UserCreationDto> postUserValidator, IValidator<UserUpdateDto> putUserValidator)
		{
			_userRepository = userRepository;
			_postUserValidator = postUserValidator;
			_putUserValidator = putUserValidator;
		}

		[HttpGet]
		public IActionResult GetAllUsers()
		{
			var users = _userRepository.GetAllUsers(trackChanges: false);

			return Ok(users);
		}

		[HttpGet("{id:int}", Name = "GetUser")]
		public IActionResult GetUser(int id)
		{
			var user = _userRepository.GetUser(id, trackChanges: false);

			return Ok(user);
		}

		[HttpPost]
		public IActionResult CreateUser([FromBody] UserCreationDto userCreationDto)
		{
			if (userCreationDto == null)
			{
				return BadRequest("userCreationDto object is null");
			}

			_postUserValidator.ValidateAndThrow(userCreationDto);

			var createdUser = _userRepository.CreateUser(userCreationDto);

			return CreatedAtRoute("GetUser", new { id = createdUser.Id }, createdUser);
		}

		[HttpDelete("{userId:int}")]
		public NoContentResult DeleteUser(int userId)
		{
			_userRepository.DeleteUser(userId, trackChanges: false);

			return NoContent();
		}

		[HttpPut("{userId:int}")]
		public IActionResult UpdateUser(int userId, [FromBody] UserUpdateDto userUpdateDto)
		{
			if (userUpdateDto == null)
			{
				return BadRequest();
			}

			_putUserValidator.ValidateAndThrow(userUpdateDto);

			_userRepository.UpdateUser(userId, userUpdateDto, trackChanges: true);

			return NoContent();
		}
	}
}

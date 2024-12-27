using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Contracts
{
	public interface IUserRepository
	{
		IEnumerable<UserDto> GetAllUsers(bool trackChanges);

		UserDto GetUser(int id, bool trackChanges);

		UserDto CreateUser(UserCreationDto user);

		void DeleteUser(int userId, bool trackChanges);

		void UpdateUser(int userId, UserUpdateDto user, bool trackChanges);
	}
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Contracts;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Models.Exceptions;
using System.Threading.Tasks;

namespace ProjectsAndTasks.Repository
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
        private readonly IMapper _mapper;
        public UserRepository(RepositoryContext context, IMapper mapper) : base(context) 
		{
            _mapper = mapper;
        }

		public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
		{
			var users = FindAll(trackChanges).OrderBy(g => g.Id).ToList();

			var usersDto = users.Select(g => _mapper.Map<UserDto>(g)).ToList();

			return usersDto;
		}

		public UserDto GetUser(int id, bool trackChanges)
		{
			var user = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

			if (user == null)
			{
				throw new UserNotFoundException(id);
			}

			var userDto = _mapper.Map<UserDto>(user);
			return userDto;
		}

		public UserDto CreateUser(UserCreationDto userCreationDto)
		{
			var user = _mapper.Map<User>(userCreationDto);

			Create(user);

			var userToReturn = _mapper.Map<UserDto>(user);

			return userToReturn;
		}

		public void DeleteUser(int userId, bool trackChanges)
		{
			var user = _context.Set<User>()
				.Where(u => u.Id == userId)
				.AsNoTracking()
				.FirstOrDefault();

			if (user == null)
			{
				throw new UserNotFoundException(userId);
			}

			Delete(user);

			_context.SaveChanges();
		}

		public void UpdateUser(int userId, UserUpdateDto userDto, bool trackChanges)
		{
			var user = FindByCondition(u => u.Id.Equals(userId), trackChanges)
				.SingleOrDefault();

			if (user == null)
			{
				throw new UserNotFoundException(userId);
			}

			_mapper.Map(userDto, user);
			_context.SaveChanges();
		}
	}
}

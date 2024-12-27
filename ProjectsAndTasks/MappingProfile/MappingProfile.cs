using AutoMapper;
using ProjectsAndTasks.DTO;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>();

            CreateMap<ProjectCreationDto, Project>()
				.ForMember(dest => dest.isCompleted, opt => opt.MapFrom(src => false))
				.ForMember(dest => dest.CompletionDate, opt => opt.MapFrom(src => (DateTime?)null))
				.ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

			CreateMap<ProjectUpdateDto, Project>();

			CreateMap<Models.Task, TaskDto>();

			CreateMap<TaskCreationDto, Models.Task>()
				.ForMember(dest => dest.isCompleted, opt => opt.MapFrom(src => false))
				.ForMember(dest => dest.CompletionDate, opt => opt.MapFrom(src => (DateTime?)null))
				.ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

			CreateMap<TaskUpdateDto, Models.Task>();

			CreateMap<User, UserDto>();

			CreateMap<UserCreationDto, User>();

			CreateMap<UserUpdateDto, User>();

			CreateMap<UserTask, UserTaskDto>();

			CreateMap<UserProject, UserProjectDto>();
		}
    }
}

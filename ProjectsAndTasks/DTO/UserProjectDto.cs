using ProjectsAndTasks.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectsAndTasks.DTO
{
	public record UserProjectDto(int UserId, int ProjectId);
}

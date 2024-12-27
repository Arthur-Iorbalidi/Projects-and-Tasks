using ProjectsAndTasks.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectsAndTasks.DTO
{
	public record UserTaskDto(int UserId, int TaskId);
}

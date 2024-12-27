namespace ProjectsAndTasks.Models
{
    public class UserTask
    {
        public int UserId { get; set; }

        public int TaskId { get; set; }

        public User User { get; set; } = null!;

        public Task Task { get; set; } = null!;
    }
}

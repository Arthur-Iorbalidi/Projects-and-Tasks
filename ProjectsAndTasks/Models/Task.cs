using ProjectsAndTasks.Enums;

namespace ProjectsAndTasks.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool isCompleted { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

		public DateTime? CompletionDate { get; set; }

		public PriorityOprtions Priority { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        public List<UserTask> UserTasks { get; set; } = [];

        public List<User> Users { get; set; } = [];
    }
}

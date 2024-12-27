using System.ComponentModel.DataAnnotations;

namespace ProjectsAndTasks.Models
{
    public class Project
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public bool isCompleted { get; set; }
        public DateTime CreationDate { get; set; }

		public DateTime? CompletionDate { get; set; }

		public string Description { get; set; } //FK

        public List<Task> Tasks { get; } = []; //Ref Nav

        public List<UserProject> UserProjects { get; } = [];

        public List<User> Users { get; } = [];
    }
}

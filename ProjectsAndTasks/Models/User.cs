using System.ComponentModel.DataAnnotations;

namespace ProjectsAndTasks.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        public List<UserTask> UserTasks { get; } = [];

        public List<Task> Tasks { get; } = [];

        public List<UserProject> UserProjects { get; } = [];

        public List<Project> Projects { get; } = [];
    }
}

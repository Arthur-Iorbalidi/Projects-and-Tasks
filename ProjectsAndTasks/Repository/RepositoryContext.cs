using Microsoft.EntityFrameworkCore;
using ProjectsAndTasks.Models;
using ProjectsAndTasks.Repository.Configuration;

namespace ProjectsAndTasks.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserProject> UserProjects { get; set; }

        public DbSet<UserTask> userTasks { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
			modelBuilder.ApplyConfiguration(new TaskConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new UserProjectConfiguration());
			modelBuilder.ApplyConfiguration(new UserTaskConfiguration());
		}
    }
}

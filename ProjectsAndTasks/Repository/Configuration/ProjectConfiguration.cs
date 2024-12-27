using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Repository.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData
            (
				new Project
				{
					Id = 1,
					Name = "Website Redesign",
					isCompleted = false,
					CreationDate = new DateTime(2023, 5, 1),
					CompletionDate = null,
					Description = "Complete overhaul of the corporate website"
				},
				new Project
				{
					Id = 2,
					Name = "Mobile App Development",
					isCompleted = false,
					CreationDate = new DateTime(2023, 6, 15),
					CompletionDate = null,
					Description = "Develop a mobile app for internal communication"
				},
				new Project
				{
					Id = 3,
					Name = "Marketing Campaign Q3",
					isCompleted = true,
					CreationDate = new DateTime(2023, 3, 12),
					CompletionDate = new DateTime(2023, 5, 12),
					Description = "Q3 campaign for product launch"
				},
				new Project
				{
					Id = 4,
					Name = "Customer Portal Upgrade",
					isCompleted = false,
					CreationDate = new DateTime(2023, 7, 30),
					CompletionDate = null,
					Description = "Upgrade features and security in the customer portal"
				},
				new Project
				{
					Id = 5,
					Name = "RDR2 Guide",
					isCompleted = false,
					CreationDate = new DateTime(2023, 1, 22),
					CompletionDate = null,
					Description = "Development of online service RDR2 Guide"
				}
			);
        }
    }
}

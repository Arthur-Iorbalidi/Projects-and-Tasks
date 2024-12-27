using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsAndTasks.Enums;

namespace ProjectsAndTasks.Repository.Configuration
{
	public class TaskConfiguration : IEntityTypeConfiguration<Models.Task>
	{
		public void Configure(EntityTypeBuilder<Models.Task> builder)
		{
			builder.HasData
			(
				new Models.Task
				{
					Id = 1,
					Name = "Design Wireframes",
					isCompleted = false,
					Description = "Create design wireframes for the website",
					CreationDate = new DateTime(2023, 5, 2),
					CompletionDate = null,
					Priority = PriorityOprtions.High,
					ProjectId = 1
				},
				new Models.Task
				{
					Id = 2,
					Name = "Develop App Backend",
					isCompleted = false,
					Description = "Develop the backend for the mobile app",
					CreationDate = new DateTime(2023, 6, 16),
					CompletionDate = null,
					Priority = PriorityOprtions.Medium,
					ProjectId = 2
				},
				new Models.Task
				{
					Id = 3,
					Name = "Launch Marketing Campaign",
					isCompleted = true,
					Description = "Execute the Q3 marketing campaign",
					CreationDate = new DateTime(2023, 3, 14),
					CompletionDate = new DateTime(2023, 5, 10),
					Priority = PriorityOprtions.High,
					ProjectId = 3
				},
				new Models.Task
				{
					Id = 4,
					Name = "Upgrade Portal Security",
					isCompleted = false,
					Description = "Enhance security features in the customer portal",
					CreationDate = new DateTime(2023, 7, 31),
					CompletionDate = null,
					Priority = PriorityOprtions.High,
					ProjectId = 4
				},
				new Models.Task
				{
					Id = 5,
					Name = "Create Models on Database",
					isCompleted = false,
					Description = "Create all necessarry models",
					CreationDate = new DateTime(2024, 10, 1),
					CompletionDate = null,
					Priority = PriorityOprtions.High,
					ProjectId = 5
				},
				new Models.Task
				{
					Id = 6,
					Name = "Create layout for website",
					isCompleted = false,
					Description = "Create layout for website for all pages",
					CreationDate = new DateTime(2023, 10, 5),
					CompletionDate = null,
					Priority = PriorityOprtions.High,
					ProjectId = 5
				},
				new Models.Task
				{
					Id = 7,
					Name = "Create Controllers",
					isCompleted = false,
					Description = "Create Controllers with necessary functionality",
					CreationDate = new DateTime(2024, 10, 10),
					CompletionDate = null,
					Priority = PriorityOprtions.High,
					ProjectId = 5
				}
			);
		}
	}
}

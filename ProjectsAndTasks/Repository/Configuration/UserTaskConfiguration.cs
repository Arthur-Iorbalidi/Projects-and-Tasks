using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Repository.Configuration
{
	public class UserTaskConfiguration : IEntityTypeConfiguration<UserTask>
	{
		public void Configure(EntityTypeBuilder<UserTask> builder)
		{
            builder.HasKey(k => new { k.UserId, k.TaskId });

            builder.HasData
			(
				new UserTask
				{
					UserId = 1,
					TaskId = 1
				},
				new UserTask
				{
					UserId = 3,
					TaskId = 2
				},
				new UserTask
				{
					UserId = 2,
					TaskId = 2
				},
				new UserTask
				{
					UserId = 3,
					TaskId = 3
				},
				new UserTask
				{
					UserId = 4,
					TaskId = 4
				},
				new UserTask
				{
					UserId = 1,
					TaskId = 5
				},
				new UserTask
				{
					UserId = 6,
					TaskId = 5
				},
				new UserTask
				{
					UserId = 2,
					TaskId = 5
				},
				new UserTask
				{
					UserId = 2,
					TaskId = 7
				},
				new UserTask
				{
					UserId = 6,
					TaskId = 7
				}
			);
		}
	}
}

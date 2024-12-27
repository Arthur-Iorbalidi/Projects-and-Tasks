using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Repository.Configuration
{
	public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
	{
		public void Configure(EntityTypeBuilder<UserProject> builder)
		{
			builder.HasKey(k => new { k.UserId, k.ProjectId });

			builder.HasData
			(
				new UserProject
				{
					UserId = 1,
					ProjectId = 1
				},
				new UserProject
				{
					UserId = 2,
					ProjectId = 2
				},
				new UserProject
				{
					UserId = 3,
					ProjectId = 3
				},
				new UserProject
				{
					UserId = 4,
					ProjectId = 4
				},
				new UserProject
				{
					UserId = 5,
					ProjectId = 4
				},
				new UserProject
				{
					UserId = 2,
					ProjectId = 5
				},
				new UserProject
				{
					UserId = 6,
					ProjectId = 5
				},
				new UserProject
				{
					UserId = 1,
					ProjectId = 5
				},
				new UserProject
				{
					UserId = 3,
					ProjectId = 2
				},
				new UserProject
				{
					UserId = 5,
					ProjectId = 3
				}
			);
		}
	}
}

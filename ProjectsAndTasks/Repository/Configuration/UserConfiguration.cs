using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = 1,
                    Name = "Arthur",
                    Surname = "Iorbalidi",
                    Email = "arthur.iorbalidi@gmail.com",
                    Password = "1111"
                },
                new User
                {
                    Id = 2,
                    Name = "Ilya",
                    Surname = "Khmelkov",
                    Email = "ilya.knmelkov@gmail.com",
                    Password = "2222"
                },
                new User
                {
                    Id = 3,
                    Name = "Alexander",
                    Surname = "Yakovlev",
                    Email = "alexander.yakovlev@gmail.com",
                    Password = "3333"
                },
                new User
                {
                    Id = 4,
                    Name = "Pavel",
                    Surname = "Fedorov",
                    Email = "pavel.fedorov@gmail.com",
                    Password = "4444"
                },
                new User
                {
                    Id = 5,
                    Name = "Nikita",
                    Surname = "Kravchenko",
                    Email = "nikita.kravchenko@gmail.com",
                    Password = "5555"
                },
				new User
				{
					Id = 6,
					Name = "Vadim",
					Surname = "Podlipny",
					Email = "vadim.podlipny@gmail.com",
					Password = "6666"
				}
			);
        }
    }
}

namespace AspPanda.Data.Repositories
{
    using AspPanda.Data.Interfaces;
    using AspPanda.Models.Entities;
    using AspPanda.Models.Enums;
    using AspPanda.Models.ViewModels;
    using System;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        private PandaDbContext dbContext;

        public UserRepository()
        {
            this.dbContext = new PandaDbContext();
        }

        public void CreateUser(RegisterViewModel registerUser)
        {
            if (dbContext.Users.Any(u => u.Username == registerUser.Username))
            {
                throw new InvalidOperationException("There is already a user with that username!");
            }

            if (dbContext.Users.Any(u => u.Email == registerUser.Email))
            {
                throw new InvalidOperationException("There is already a user with that email!");
            }

            if (dbContext.Users.Any())
            {
                var user = new User
                {
                    Username = registerUser.Username,
                    Password = registerUser.Password,
                    Email = registerUser.Email,
                    Role = Role.User
                };

                dbContext.Users.Add(user);
            }
            else
            {
                var user = new User
                {
                    Username = registerUser.Username,
                    Password = registerUser.Password,
                    Email = registerUser.Email,
                    Role = Role.Admin
                };

                dbContext.Users.Add(user);
            }
            dbContext.SaveChanges();
        }
    }
}

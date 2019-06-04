namespace Panda.Services
{
    using System;
    using System.Linq;
    using Panda.Data;
    using Panda.Models.Entities;
    using Panda.Services.Interfaces;

    public class UserService : IUserService
    {
        private PandaDbContext _dbContext;

        public UserService(PandaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public MyIdentityUser GetUserById(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user");
            }

            return user;
        }
    }
}

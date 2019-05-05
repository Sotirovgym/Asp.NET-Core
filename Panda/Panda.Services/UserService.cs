namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda.Data;
    using Panda.Models.Entities;
    using Panda.Models.Enums;
    using Panda.Services.Interfaces;

    public class UserService : IUserService
    {
        private PandaDbContext _dbContext;

        public UserService(PandaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Package> GetPackages(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var userPackages = _dbContext.Packages
                .Where(p => p.Id.CompareTo(user.Id) == 0)
                .ToArray();

            return userPackages;
        }

        public IEnumerable<Package> GetPackagesByStatus(Status status)
        {
            var packagesByStatus = _dbContext.Packages
                .Where(p => p.Status == status)
                .ToArray();

            return packagesByStatus;
        }
    }
}

namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda.Data;
    using Panda.Models.Entities;
    using Panda.Models.Enums;
    using Panda.Services.Interfaces;

    public class PackageService : IPackageService
    {
        private PandaDbContext _dbContext;

        public PackageService(PandaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreatePackage(Package package)
        {
            this._dbContext.Packages.Add(package);
            this._dbContext.SaveChanges();
        }

        public Package GetPackageById(Guid id)
        {
            var package = this._dbContext.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                throw new InvalidOperationException("There is no such package!");
            }

            return package;
        }

        public IEnumerable<Package> GetPackages()
        {
            var packages = this._dbContext.Packages.Select(p => p).ToArray();

            return packages;
        }

        public IEnumerable<Package> GetPendingPackagesByUser(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var packages = _dbContext.Packages
                .Where(p => p.RecipientId == user.Id && p.Status == Status.Pending)
                .ToArray();

            return packages;
        }

        public IEnumerable<Package> GetShippedPackagesByUser(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var packages = _dbContext.Packages
                .Where(p => p.RecipientId == user.Id && p.Status == Status.Shipped)
                .ToArray();

            return packages;
        }

        public IEnumerable<Package> GetDeliveredAndAcquiredPackagesByUser(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var packages = _dbContext.Packages
                .Where(p => p.RecipientId == user.Id && p.Status == Status.Delivered || p.Status == Status.Acquired)
                .ToArray();

            return packages;
        }

        public IEnumerable<Package> GetUserPackages(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var userPackages = _dbContext.Packages
                .Where(p => p.RecipientId == user.Id)
                .ToArray();

            return userPackages;
        }
    }
}

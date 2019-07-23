namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
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

        public void AddPackage(Package package)
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

        public IEnumerable<Package> GetShippedPackages()
        {
            var packages = _dbContext.Packages
                .Where(p => p.Status == Status.Shipped)
                .Include(p => p.Recipient)
                .ToArray();

            return packages;
        }

        public IEnumerable<Package> GetPendingPackages()
        {
            var packages = _dbContext.Packages.Where(p => p.Status == Status.Pending)
                                              .Include(p => p.Recipient)
                                              .ToArray();

            return packages;
        }

        public IEnumerable<Package> GetDeliveredAndAcquiredPackages()
        {
            var packages = _dbContext.Packages.Where(p => p.Status == Status.Delivered || p.Status == Status.Acquired)
                                              .Include(p => p.Recipient)
                                              .ToArray();

            return packages;
        }

        public IEnumerable<Package> GetUserPackagesByStatus(string username, Status status)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var packages = _dbContext.Packages
                .Where(p => p.RecipientId == user.Id && p.Status == status)
                .ToArray();

            return packages;
        }

        public void SetStatusToAcquired(Guid id)
        {
            var package = _dbContext.Packages.FirstOrDefault(p => p.Id == id);
            package.Status = Status.Acquired;
            _dbContext.SaveChanges();
        }

        public void ShipPackage(Guid packageId)
        {
            var package = _dbContext.Packages.FirstOrDefault(p => p.Id == packageId);

            if (package == null)
            {
                throw new InvalidOperationException("There is no such package.");
            }

            package.Status = Status.Shipped;
            _dbContext.SaveChanges();
        }

        public void DeliverPackage(Guid packageId)
        {
            var package = _dbContext.Packages.FirstOrDefault(p => p.Id == packageId);

            if (package == null)
            {
                throw new InvalidOperationException("There is no such package.");
            }

            package.Status = Status.Delivered;
            _dbContext.SaveChanges();
        }
    }
}

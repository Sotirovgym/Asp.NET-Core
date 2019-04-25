namespace Panda.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda.Data;
    using Panda.Models.Entities;
    using Panda.Services.Interfaces;

    public class PackageRepository : IPackageRepository
    {
        private PandaDbContext dbContext;

        public PackageRepository()
        {
            this.dbContext = new PandaDbContext();
        }

        public void CreatePackage(Package package)
        {
            this.dbContext.Packages.Add(package);
            this.dbContext.SaveChanges();
        }

        public Package GetPackageById(Guid id)
        {
            var package = this.dbContext.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                throw new InvalidOperationException("There is no such package!");
            }

            return package;
        }

        public IEnumerable<Package> GetPackages()
        {
            var packages = this.dbContext.Packages.Select(p => p).ToArray();
            return packages;
        }
    }
}

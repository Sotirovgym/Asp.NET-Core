namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda.Data;
    using Panda.Models.Entities;
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
    }
}

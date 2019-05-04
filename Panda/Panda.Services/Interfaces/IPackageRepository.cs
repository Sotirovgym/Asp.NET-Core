namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using System;
    using System.Collections.Generic;

    public interface IPackageService
    {
        IEnumerable<Package> GetPackages();

        Package GetPackageById(Guid id);

        void CreatePackage(Package package);
    }
}

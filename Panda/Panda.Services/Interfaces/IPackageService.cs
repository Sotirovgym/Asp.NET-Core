namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using Panda.Models.Enums;
    using System;
    using System.Collections.Generic;

    public interface IPackageService
    {
        IEnumerable<Package> GetPackages();

        Package GetPackageById(Guid id);

        void CreatePackage(Package package);

        IEnumerable<Package> GetUserPackages(string username);

        IEnumerable<Package> GetShippedPackagesByUser(string username);

        IEnumerable<Package> GetPendingPackagesByUser(string username);

        IEnumerable<Package> GetDeliveredAndAcquiredPackagesByUser(string username);
    }
}

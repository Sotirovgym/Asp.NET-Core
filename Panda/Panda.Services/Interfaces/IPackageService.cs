namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using Panda.Models.Enums;
    using System;
    using System.Collections.Generic;

    public interface IPackageService
    {
        Package GetPackageById(Guid id);

        void AddPackage(Package package);

        void SetStatusToAcquired(Guid id);

        IEnumerable<Package> GetUserPackagesByStatus(string username, Status status);

        IEnumerable<Package> GetShippedPackages();

        IEnumerable<Package> GetPendingPackages();

        IEnumerable<Package> GetDeliveredAndAcquiredPackages();
    }
}

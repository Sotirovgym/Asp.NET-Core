namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using System.Collections.Generic;

    public interface IPackageRepository
    {
        IEnumerable<Package> GetPackages();

        Package GetPackageById(int id);

        void CreatePackage(Package package);
    }
}

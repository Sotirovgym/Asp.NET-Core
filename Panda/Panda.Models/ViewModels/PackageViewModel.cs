namespace Panda.Models.ViewModels
{
    using Panda.Models.Entities;
    using System.Collections.Generic;

    public class PackageViewModel
    {
        public PackageViewModel(IEnumerable<Package> pendingPackages, IEnumerable<Package> shippedPackages, IEnumerable<Package> deliveredPackages)
        {
            this.PendingPackages = pendingPackages;
            this.ShippedPackages = shippedPackages;
            this.DeliveredPackages = deliveredPackages;
        }

        public IEnumerable<Package> PendingPackages { get; set; }

        public IEnumerable<Package> ShippedPackages { get; set; }

        public IEnumerable<Package> DeliveredPackages { get; set; }
    }
}

namespace Panda.Models.ViewModels
{
    using Panda.Models.Entities;
    using System.Collections.Generic;

    public class CreatePackageViewModel
    {
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public int UserId { get; set; }

        public IEnumerable<MyIdentityUser> Users { get; set; }
    }
}

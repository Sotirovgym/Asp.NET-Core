namespace Panda.Models.ViewModels
{
    using Panda.Models.Enums;
    using System;

    public class PackageDetailsViewModel
    {
        public Guid Id { get; set; }
        
        public string Description { get; set; }
        
        public decimal Weight { get; set; }
        
        public string ShippingAddreess { get; set; }
        
        public Status Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string RecipientName { get; set; }
    }
}

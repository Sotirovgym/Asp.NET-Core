namespace Panda.Models.ViewModels
{
    using System;

    public class ReceiptDetailsViewModel
    {
        public Guid Id { get; set; }
        
        public DateTime IssuedOn { get; set; }
        
        public string DeliveryAddress { get; set; }
        
        public decimal PackageWeight { get; set; }

        public string PackageDescription { get; set; }

        public string Recipient { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

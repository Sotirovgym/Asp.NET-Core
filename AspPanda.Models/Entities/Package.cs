namespace AspPanda.Models.Entities
{
    using AspPanda.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        public Package()
        {
            this.Receipts = new HashSet<Receipt>();
        }

        [Required]
        public Guid Id { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Weight { get; set; }

        [Required]
        [MaxLength(150)]
        public string ShippingAddreess { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }

        public Guid RecipientId { get; set; }
        [Required]
        public User Recipient { get; set; }

        public IEnumerable<Receipt> Receipts { get; set; }
    }
}

﻿namespace Panda.Models.Entities
{
    using Panda.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Package
    {
        public Package()
        {
            this.Receipts = new HashSet<Receipt>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Weight { get; set; }

        [Required]
        [MaxLength(150)]
        public string ShippingAddreess { get; set; }

        [Required]
        public Status Status { get; set; }
        
        public DateTime? EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }
        [Required]
        public MyIdentityUser Recipient { get; set; }

        public IEnumerable<Receipt> Receipts { get; set; }
    }
}

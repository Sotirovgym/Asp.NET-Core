﻿namespace AspCorePanda.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Receipt
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 79228162514264337593543950335.0)]
        public decimal Fee { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        public Guid RecipientId { get; set; }
        [Required]
        public User Recipient { get; set; }

        public Guid PackageId { get; set; }
        [Required]
        public Package Package { get; set; }
    }
}
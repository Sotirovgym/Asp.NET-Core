namespace Panda.Models.ViewModels
{
    using Panda.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreatePackageViewModel
    {
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(1, 1.7976931348623157E+308, ErrorMessage = "Weight should be higher than 0.")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Shipping Address is required.")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Recipient is required.")]
        public Guid UserId { get; set; }

        public IEnumerable<MyIdentityUser> Users { get; set; }
    }
}

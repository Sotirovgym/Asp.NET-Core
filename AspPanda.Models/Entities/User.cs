namespace AspCorePanda.Data.Models
{
    using AspCorePanda.Data.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Packages = new List<Package>();
            this.Receipts = new List<Receipt>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; }
        [RegularExpression(@"^[a-z A-Z]+@[a-z A-Z]+\.[a-z A-Z]+$")]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }

        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}

namespace Panda.Models.Entities
{
    using Microsoft.AspNetCore.Identity;
    using Panda.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    // Add profile data for application users by adding properties to the MyIdentityUser class
    public class MyIdentityUser : IdentityUser
    {
        public MyIdentityUser()
        {
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }
        
        [Required]
        public Role Role { get; set; }

        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}

namespace Panda.Models.Entities
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Receipt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 79228162514264337593543950335.0)]
        public decimal Fee { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        public string RecipientId { get; set; }
        [Required]
        public MyIdentityUser Recipient { get; set; }

        public Guid PackageId { get; set; }
        [Required]
        public Package Package { get; set; }
    }
}

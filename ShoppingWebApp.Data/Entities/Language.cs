using ShoppingWebApp.Data.Enums;
using ShoppingWebApp.Data.Interfaces;
using ShoppingWebApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApp.Data.Entities
{
    [Table("Languages")]
    public class Language : BaseEntity<string>, ISwitchable
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}

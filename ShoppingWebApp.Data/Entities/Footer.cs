using ShoppingWebApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApp.Data.Entities
{
    [Table("Footers")]
    public class Footer : BaseEntity<string>
    {
        [Required]
        public string Content { set; get; }
    }
}

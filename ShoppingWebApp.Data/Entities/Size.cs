using ShoppingWebApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApp.Data.Entities
{
    [Table("Sizes")]
    public class Size : BaseEntity<int>
    {
        [StringLength(250)]
        public string Name
        {
            get; set;
        }
    }
}
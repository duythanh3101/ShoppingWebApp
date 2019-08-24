using ShoppingWebApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApp.Data.Entities
{

    [Table("WholePrices")]
    public class WholePrice: BaseEntity<int>
    {
        public int ProductId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}

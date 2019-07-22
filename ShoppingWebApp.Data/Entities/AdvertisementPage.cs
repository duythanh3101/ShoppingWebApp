using ShoppingWebApp.Infrastructure.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApp.Data.Entities
{
    [Table("AdvertisementPages")]
    public class AdvertisementPage : BaseEntity<string>
    {
        public AdvertisementPage()
        {
            AdvertisementPositions = new List<AdvertisementPosition>();
        }

        public string Name { get; set; }

        public virtual ICollection<AdvertisementPosition> AdvertisementPositions { get; set; }
    }
}

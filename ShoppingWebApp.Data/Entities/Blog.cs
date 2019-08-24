using ShoppingWebApp.Data.Enums;
using ShoppingWebApp.Data.Interfaces;
using ShoppingWebApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingWebApp.Data.Entities
{
    [Table("Blogs")]
    public class Blog : BaseEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public string Name { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }


        [MaxLength(256)]
        public string SeoPageTitle { get; set; }

        [MaxLength(256)]
        public string SeoAlias { get; set; }

        [MaxLength(256)]
        public string SeoKeywords { get; set; }

        [MaxLength(256)]
        public string SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<BlogTag> BlogTags { get; set; }

    }
}

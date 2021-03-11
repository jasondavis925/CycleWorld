using CycleWorld.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Data
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [ForeignKey(nameof(Part))]
        public int? PartId { get; set; }
        public virtual Part Part { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        public string Services { get; set; }

        public string Location { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}

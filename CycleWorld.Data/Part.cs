
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Data
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string PartName { get; set; }

        [Required]
        public string ModelNumber { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string TypeOfPart { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [Required]
        public int NumberInInventory { get; set; }

        [Required]
        public bool IsInStock
        {
            get
            {
                return NumberInInventory > 0;
            }
        }
    }
}


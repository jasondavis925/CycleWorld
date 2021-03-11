using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class PartDetail
    {
        public int PartId { get; set; }
        
        [Display(Name = "Name of Part")]
        public string PartName { get; set; }

        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }
        
        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        [Display(Name = "Type")]
        public string TypeOfPart { get; set; }

        [Display(Name = "Description of Part")]
        public string Description { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = "Number in Inventory")]
        public int NumberInInventory { get; set; }
    }
}


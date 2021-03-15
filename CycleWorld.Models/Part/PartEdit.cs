using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class PartEdit
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string ModelNumber { get; set; }
        public string Manufacturer { get; set; }
        public string TypeOfPart { get; set; }
        public int NumberInInventory { get; set; }
    }
}

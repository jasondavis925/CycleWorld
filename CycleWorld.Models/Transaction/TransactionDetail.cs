using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }

        [Display(Name = "Purchased By")]
        public int UserId { get; set; }

        [Display(Name = "Part Purchased")]
        public string PartId { get; set; }

        [Display(Name = "Quantity Purchased")]
        public int ItemCount { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTimeOffset DateOfTransaction { get; set; }
    }
}

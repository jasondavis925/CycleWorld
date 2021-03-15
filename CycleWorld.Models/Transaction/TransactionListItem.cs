using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Part")]
        public string PartId { get; set; }

        [Display(Name = "Quantity of Parts Purchased")]
        public int ItemCount { get; set; }

        [Display(Name = "Date of Purchase")]
        public DateTimeOffset DateOfTransaction { get; set; }

    }
}

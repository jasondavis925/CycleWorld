using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Part))]
        public int? PartId { get; set; }
        public virtual Part Part { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public DateTimeOffset DateOfTransaction { get; set; }
    }
}

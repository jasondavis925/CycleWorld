
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Data
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        public Guid PersonalId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }

        // public List<Bike> ListOfBikes { get; set; }
        [ForeignKey(nameof(Bike))]
        public int? BikeId { get; set; }
        public virtual Bike Bike { get; set; }

        [ForeignKey(nameof(Shop))]
        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class UserListItem
    {
        public int UserId { get; set; }

        [Display(Name = "Name of User")]
        public string Name { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Bikes Owned")]
        public int? BikeId { get; set; }
        //public string BikeMake { get; set; }
        //public string BikeModel { get; set; }
        //public int BikeYear { get; set; }

        public int? ShopId { get; set; }
        public string ShopName { get; set; }

    }
}

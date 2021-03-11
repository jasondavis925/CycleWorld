using CycleWorld.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class UserEdit
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public int? BikeId { get; set; }
        //public virtual Bike Bike { get; set; }

        public int? ShopId { get; set; }
        //public virtual Shop Shop { get; set; }

    }
}

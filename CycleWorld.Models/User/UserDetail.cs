

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class UserDetail
    {
        public int UserId { get; set; }

        [Display(Name = "Name of User")]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        
        public int? BikeId { get; set; }
        [Display(Name = "Bike(s) Owned")]
        public virtual BikeListItem Bike { get; set; }

        public int? ShopId { get; set; }
        [Display(Name = "Local Shop")]
        public virtual ShopListItem Shop { get; set; }

    }
}

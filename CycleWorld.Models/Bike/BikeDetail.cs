using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class BikeDetail
    {
        public int BikeId { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }

        public decimal? Mileage { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}

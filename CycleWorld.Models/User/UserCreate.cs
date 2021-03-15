using CycleWorld.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class UserCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]

        [Display(Name = "Name of User")]
        public string Name { get; set; }

        [MaxLength(8000)]
        [Display(Name = "Biography")]
        public string Bio { get; set; }


        public int? BikeId { get; set; }
        //public virtual Bike Bike { get; set; }

        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }

       

    }
}

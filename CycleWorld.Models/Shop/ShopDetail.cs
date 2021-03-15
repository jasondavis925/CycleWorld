﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Models
{
    public class ShopDetail
    {
        public int ShopId { get; set; }

        [Display(Name = "Name of Shop")]
        public string ShopName { get; set; }

        [Display(Name = "Available Services")]
        public string Services { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
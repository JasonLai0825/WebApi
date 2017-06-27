using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaTest.Models
{
    public class Subscription
    {
        [Required]
        public int MId { get; set; }
        [Required]
        public int SId { get; set; }
    }
}
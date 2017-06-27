using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaTest.Models
{
    public class Shop
    {
        [Required]
        public int S_Id { get; set; }
        [Required]
        public string S_Name { get; set; }
        [Required]
        public string S_Phone { get; set; }
        [Required]
        public string S_Address { get; set; }
        [Required]
        public string S_LatLng { get; set; }
        [Required]
        public string S_OpenTime { get; set; }
        [Required]
        public string S_Type { get; set; }
        [Required]
        public int S_Evaluation { get; set; }
        [Required]
        public string S_Status { get; set; }
        [Required]
        public string S_Menu { get; set; }
        [Required]
        public string S_Photo { get; set; }
    }
}
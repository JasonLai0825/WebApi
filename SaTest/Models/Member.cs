using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaTest.Models
{
    public class Member
    {
        [Required]
        public int M_Id { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string passWd { get; set; }
        [Required]
        public string M_Name { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public string E_mail { get; set; }
        [Required]
        public string M_Phone { get; set; }
    }
}
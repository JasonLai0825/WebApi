using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaTest.Models
{
    public class Post
    {
        [Required]
        public int P_Id { get; set; }
        [Required]
        public int SId { get; set; }
        [Required]
        public string P_Content { get; set; }
        [Required]
        public string P_PostTime { get; set; }
        [Required]
        public string SName { get; set; }
    }
}
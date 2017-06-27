using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaTest.Models
{
    public class Comment
    {
        [Required]
        public int C_Id { get; set; }
        [Required]
        public int SId { get; set; }
        [Required]
        public string C_Publisher { get; set; }
        [Required]
        public string C_PostTime { get; set; }
        [Required]
        public string C_Content { get; set; }
        [Required]
        public string C_Title { get; set; }
        [Required]
        public int C_EvaLevel { get; set; }
    }
}
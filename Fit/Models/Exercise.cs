using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fit.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Display(Name = "Øvelses navn")]
        public string Title { get; set; }
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        public string Tag { get; set; }
        [Display(Name = "Billede")]
        public string ImagePath { get; set; }
        public bool Selected { get; set; }
    }
}
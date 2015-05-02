using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fit.Models
{
    public class WorkOutPlan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description  {get; set; }
        public List<Exercise> Exercises { get; set; }
        
        public DateTime CreationTime { get; set; }
    }   
}
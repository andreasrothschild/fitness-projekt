using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fit.Models
{
    public class FitContext : DbContext
    {
      public   DbSet<Exercise> Exercises { get; set; }
      public   DbSet<WorkOutPlan> WorkOutPlans { get; set; }

        
    }
}
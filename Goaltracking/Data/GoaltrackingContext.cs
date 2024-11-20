using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Goaltracking.Models;

namespace Goaltracking.Data
{
    public class GoaltrackingContext : DbContext
    {
        public GoaltrackingContext (DbContextOptions<GoaltrackingContext> options)
            : base(options)
        {
        }

        public DbSet<Goaltracking.Models.GoalTrackingApp> GoalTrackingApp { get; set; }
    }
}

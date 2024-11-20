using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Goaltracking.Models
{
    public class GoalTrackingApp
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Target must be greater than or equal to 0")]
        public double Target { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Progress must be greater than or equal to 0")]
        public double Progress { get; set; }

        // Automatically calculate progress percentage
        public double ProgressPercentage => Target > 0 ? (Progress / Target) * 100 : 0;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrientationRetake.Models.Entities
{
    public class Mountain
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public DateTime? FirstClimbed { get; set; }
        public List<Climber> ClimbedClimbers { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrientationRetake.Models.Entities
{
    public class Mountain
    {
        [Key]
        public long Id { get; set; }
        public string MountName { get; set; }
        public int Height { get; set; }
        public int DifficultyLevel { get; set; }
        public DateTime? FirstClimbed { get; set; }
        public List<Climber> ClimbedClimbers { get; set; }

        public Mountain()
        {
            if (Height > 1000)
            {
                DifficultyLevel++;
            }
            else if(Height > 1000)
            {
                DifficultyLevel++;
            }
            else if(Height > 2000)
            {
                DifficultyLevel++;
            }
            else if(Height > 3000)
            {
                DifficultyLevel++;
            }
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrientationRetake.Models.Entities
{
    public class Climber
    {
        [Key]
        public long Id { get; set; }
        public string  Name { get; set; }
        public string  Nationality { get; set; }
        public int Altitude { get; set; }
        public bool IsInjured { get; set; }
        public long MountainId { get; set; }
        public Mountain Mountain { get; set; }

        public Climber(string name, string nationality, int altitude, long mountainId)
        {
            Name = name;
            Nationality = nationality;
            Altitude = altitude;
            MountainId = mountainId;
            IsInjured = false;
        }
    }
}
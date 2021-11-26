using System.Collections.Generic;
using OrientationRetake.Models.Entities;

namespace OrientationRetake.Models.ViewModels
{
    public class MainViewModel
    {
        public List<Climber> AllClimbers { get; set; }
        public List<Mountain> AllMountains { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrientationRetake.Database;
using OrientationRetake.Models.Entities;

namespace OrientationRetake.Services
{
    public class ClimberService
    {
        private ApplicationDbContext DbContext { get; set; }

        public ClimberService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Climber> GetAllClimbers()
        {
            return DbContext.Climbers.Include(m => m.Mountain).ToList();
        }

        public Climber GetById(long id)
        {
            return DbContext.Climbers.FirstOrDefault(m => m.Id == id);
        }

        public void AddClimber(string name, string nationality, Mountain mountain)
        {
            Climber climber = new Climber(name, name, 0, mountain.Id);
            mountain.ClimbedClimbers.Add(climber);
            DbContext.Climbers.Add(climber);
            DbContext.SaveChanges();
        }

        public void Climb(long id, int distance)
        {
            var climber = GetById(id);
            var rnd = new Random();
            var maxnum = climber.Mountain.DifficultyLevel * 10;
            var randNum = rnd.Next(1, maxnum);
            if (randNum % 2 == 0)
            {
                climber.IsInjured = true;
            }
            else
            {
                climber.Altitude += distance;
                if (climber.Altitude == climber.Mountain.Height)
                {
                    climber.Mountain.FirstClimbed = DateTime.Now;
                }

                DbContext.SaveChanges();
            }
        }

        public List<Climber> SearchApi(string nationality, int above)
        {
            return DbContext.Climbers.Where(c => c.Nationality.Contains(nationality) && c.Altitude > above).ToList();
        }

        public void Rescue(Climber climber)
        {
            climber.Altitude = 0;
            climber.IsInjured = false;
        }
    }
}
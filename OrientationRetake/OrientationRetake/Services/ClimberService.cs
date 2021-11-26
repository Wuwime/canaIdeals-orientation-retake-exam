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
            Climber climber = new Climber(name, nationality, 0, mountain.Id);
            climber.Mountain = mountain;
            DbContext.Climbers.Add(climber);
            mountain.ClimbedClimbers.Add(climber);
            DbContext.SaveChanges();
        }

        public void Climb(long id, int distance)
        {
            var climber = GetById(id);
            var rnd = new Random();
            MountainService service = new MountainService(DbContext);
            var mountain = service.GetById(climber.MountainId);
            var maxnum = mountain.DifficultyLevel * 10;
            var randNum = rnd.Next(1, maxnum);
            if (randNum % 2 == 0)
            {
                climber.IsInjured = true;
            }
            else if(maxnum == 0)
            {
                climber.Altitude += distance;
                if (climber.Altitude == climber.Mountain.Height)
                {
                    climber.Mountain.FirstClimbed = DateTime.Now;
                }
                DbContext.SaveChanges();
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
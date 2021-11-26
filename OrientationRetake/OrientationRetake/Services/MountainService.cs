using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrientationRetake.Database;
using OrientationRetake.Models.Entities;

namespace OrientationRetake.Services
{
    public class MountainService
    {
        private ApplicationDbContext DbContext { get; set; }

        public MountainService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Mountain> GeatAllMountains()
        {
            return DbContext.Mountains.Include(m => m.ClimbedClimbers).ToList();
        }

        public Mountain GetById(long id)
        {
            return DbContext.Mountains.FirstOrDefault(m => m.Id == id);
        }
    }
}
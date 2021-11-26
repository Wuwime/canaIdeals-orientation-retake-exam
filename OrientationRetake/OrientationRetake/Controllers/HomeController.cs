using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrientationRetake.Models.Entities;
using OrientationRetake.Models.ViewModels;
using OrientationRetake.Services;

namespace OrientationRetake.Controllers
{
    public class HomeController : Controller
    {
        private ClimberService ClimberService { get; set; }
        private MountainService MountainService { get; set; }

        public HomeController(ClimberService climberService, MountainService mountainService)
        {
            ClimberService = climberService;
            MountainService = mountainService;
        }

        [Route("")]
        public IActionResult MainPage()
        {
            return View(new MainViewModel(){AllClimbers = ClimberService.GetAllClimbers(), AllMountains = MountainService.GeatAllMountains()});
        }

        [HttpGet("mountains/{id=long}")]
        public IActionResult MountainDetail([FromRoute] long id)
        {
            var mountain = MountainService.GetById(id);
            return View(new MainViewModel() {Mountain = mountain});
        }

        [HttpPost("climbers")]
        public IActionResult AddClimber([FromForm]string name, string nationality, long mountainId)
        {
            var mountain = MountainService.GetById(mountainId);
            ClimberService.AddClimber(name, nationality, mountain);
            
            return View("MainPage",new MainViewModel(){AllClimbers = ClimberService.GetAllClimbers(), AllMountains = MountainService.GeatAllMountains()});
        }
        
        [HttpPost("climbers/climb")]
        public IActionResult ClimbersClimb([FromForm] long climberId, int distance)
        {
            ClimberService.Climb(climberId, distance);
            return View("MainPage",new MainViewModel(){AllClimbers = ClimberService.GetAllClimbers(), AllMountains = MountainService.GeatAllMountains()});
        }
        
        [HttpPost("climbers/{id=long}/rescue/")]
        public IActionResult ClimbersRescue([FromRoute] long id)
        {
            var toRescue = ClimberService.GetById(id);
            if (toRescue.IsInjured == true)
            {
                ClimberService.Rescue(toRescue);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet("api/climbers")]
        public IActionResult Api([FromQuery] string nationality, int above)
        {
            var apiList = ClimberService.SearchApi(nationality, above);
            return Ok(new { ebooks = apiList.Select(x => new { x.Name, x.Nationality, x.Altitude, x.IsInjured, x.Mountain.MountName }).ToList() });
        }
    }
}
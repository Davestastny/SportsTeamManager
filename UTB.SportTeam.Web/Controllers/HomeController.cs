using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UTB.SportTeam.Application.Abstraction;
using UTB.SportTeam.Web.Models.ViewModel;

namespace UTB.SportTeam.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamAppService teamAppService;

        public HomeController(ITeamAppService teamAppService)
        {
            this.teamAppService = teamAppService;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel
            {
                Teams = teamAppService.GetAll()
            };
            return View(viewModel);
        }

        // Detail týmu: soupiska, tréninky, zápasy
        public IActionResult Team(int id)
        {
            var team = teamAppService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            TeamDetailViewModel viewModel = new TeamDetailViewModel
            {
                Team = team,
                Players = teamAppService.GetPlayers(id),
                Trainings = teamAppService.GetTrainings(id),
                Matches = teamAppService.GetMatches(id)
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

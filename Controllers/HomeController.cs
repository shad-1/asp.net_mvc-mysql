using System;
using System.Linq;
using bowlers.Models;
using bowlers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bowlers.Controllers
{
	public class HomeController : Controller
	{
		private IBowlersRepository _repo { get; set; }

		public HomeController(IBowlersRepository repo)
		{
			_repo = repo;
		}

		public IActionResult Index(int team = 0)
        {
			
			Team selectedTeam = new Team
            {
				TeamID = 0,
				TeamName = "All Teams"
			};

			if (team > 0)
			{
				selectedTeam = _repo.Teams.Where(t => t.TeamID == team).First();
            }

			//try
			//{
			//	var temp = _repo.Teams.FirstOrDefault(t => t.TeamID == team);
			//}
			//catch (Exception e)
   //         {
			//	Console.WriteLine(e);
   //         }

			ViewBag.SelectedTeam = selectedTeam;

			var teams = _repo.Teams.ToList();

            var bowlers = _repo.Bowlers
				// sort bowlers based on TeamID
				.Where(b => b.TeamID == team || team == 0)
				.OrderBy(b => b.TeamID)
				.ThenBy(b => b.BowlerLastName)
				.ToList();

			var bt = new BowlerTeamViewModel
			{
				Teams = teams,
				Bowlers = bowlers
			};
			return View(bt);
        }
	}
}


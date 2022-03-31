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
			// This is used for Setting the Team Name at top of page when no team is selected
			Team selectedTeam = new Team
            {
				TeamID = 0,
				TeamName = "All Teams"
			};
            // If a team is selected, show their name
			if (team > 0)
			{
				selectedTeam = _repo.Teams.Where(t => t.TeamID == team).First();
            }
            // I am passing the whole team object when just a name could more simply suffice. I acknowledge that and will inform you it was part of a larger strategy. 
			ViewBag.SelectedTeam = selectedTeam;


			var teams = _repo.Teams.ToList();

            var bowlers = _repo.Bowlers
				// sort bowlers based on TeamID
				.Where(b => b.TeamID == team || team == 0)
				.OrderBy(b => b.TeamID)
				.ThenBy(b => b.BowlerLastName)
				.ToList();

            //Keeps whole objects totally accessible
			var bt = new BowlerTeamViewModel
			{
				Teams = teams,
				Bowlers = bowlers
			};
			return View(bt);
        }

		[HttpGet]
        public IActionResult AddBowler()
        {
            //Need list of teams for dropdown
            ViewBag.Teams = _repo.Teams.ToList<Team>();
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if(ModelState.IsValid)
            {
                b.BowlerID = _repo.Bowlers.Max(b => b.BowlerID) + 1;
                _repo.Add(b);

                //Redirect to Index view
                return RedirectToAction("Index");
            }
            //If invalid, return the form.
            else
            {
                ViewBag.Teams = _repo.Teams.ToList<Team>();
                return View(b);
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Wrap it in a try-catch block to handle weird errors.
            try
            {
                Bowler b = _repo.Bowlers.Single(b => b.BowlerID == id);
                ViewBag.Teams = _repo.Teams.ToList<Team>();
                return View("AddBowler", b); //Add page has correct form to handle this.
            }
            catch
            {
                Console.WriteLine("Uhhh...we couldn't find the Bowler whose ID was submitted. This error should never trigger.");
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if(ModelState.IsValid)
            { 
                _repo.Update(b);

                return RedirectToAction("Index");
            }
            //If invalid, return the form.
            else
            {
                ViewBag.Teams = _repo.Teams.ToList<Team>();
                return View("AddBowler", b);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(bowler); 
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.Delete(b);
            return RedirectToAction("Index");
        }
	}
}


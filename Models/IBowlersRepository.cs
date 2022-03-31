using System;
using System.Linq;

namespace bowlers.Models
{
	public interface IBowlersRepository
	{
		IQueryable<Bowler> Bowlers { get; }
		IQueryable<Team> Teams { get; }
	}
}


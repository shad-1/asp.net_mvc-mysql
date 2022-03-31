using System;
using System.Linq;

namespace bowlers.Models
{
	public interface IBowlersRepository
	{
		IQueryable<Bowler> Bowlers { get; }
		IQueryable<Team> Teams { get; }

		//Methods to implement to interface with the context. 
		void Add(Bowler b);
		void Update(Bowler b);
		void Delete(Bowler b);
	}
}


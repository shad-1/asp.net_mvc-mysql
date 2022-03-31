using System;
using System.Linq;

namespace bowlers.Models
{
	public class EFBowlersRepository : IBowlersRepository
	{
		private BowlerContext _ctx { get; set; }

		public EFBowlersRepository(BowlerContext ctx)
		{
			_ctx = ctx;
		}

		public IQueryable<Bowler> Bowlers => _ctx.Bowlers;

		public IQueryable<Team> Teams => _ctx.Teams;
    }
}


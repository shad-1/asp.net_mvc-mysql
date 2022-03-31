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

		// All 3 of these methods access the context but preserve the layer of abstraction between the controller and the context.
		// Shoutout to people who answered questions on slack. 
		public void Add (Bowler b)
        {
			_ctx.Bowlers.Add(b);
			_ctx.SaveChanges();
        }

		public void Update (Bowler b)
		{
			_ctx.Bowlers.Update(b);
			_ctx.SaveChanges();
		}

		public void Delete (Bowler b)
        {
			_ctx.Bowlers.Remove(b);
			_ctx.SaveChanges();
        }
    }
}


using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace bowlers.Models
{
	public class BowlerContext : DbContext
	{
		public BowlerContext(DbContextOptions<BowlerContext> options) : base (options)
		{
		}

		public DbSet<Bowler> Bowlers { get; set; }

		public DbSet<Team> Teams { get; set; }

	}
}


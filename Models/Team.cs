using System;
using System.ComponentModel.DataAnnotations;

namespace bowlers.Models
{
	public class Team
	{
        public Team()
		{
		}

        [Key]
		[Required]
		public int TeamID { get; set; }
		[Required]
		public string TeamName { get; set; }
		#nullable enable
		public int? CaptainID { get; set; }
	}
}


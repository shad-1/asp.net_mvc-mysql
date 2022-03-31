using System;
using System.ComponentModel.DataAnnotations;

namespace bowlers.Models
{
	public class Bowler
	{
		public Bowler()
		{
		}
        [Key]
        [Required]
        public int BowlerID { get; set; }
        [Required]
        public string BowlerLastName { get; set; }
        [Required]
        public int TeamID { get; set; }
        #nullable enable
        public string? BowlerFirstName { get; set; }
        public char? BowlerMiddleInit { get; set; }
        public string? BowlerAddress { get; set; }
        public string? BowlerCity { get; set; }
        public string? BowlerState { get; set; }
        public string? BowlerZip { get; set; }
        public string? BowlerPhoneNumber { get; set; }
    }
}


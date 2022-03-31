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
        [Required(ErrorMessage = "Enter a Last Name")]
        public string BowlerLastName { get; set; }
        [Required(ErrorMessage = "Please pick a team")]
        public int TeamID { get; set; }
        #nullable enable
        [MaxLength(50)]
        public string? BowlerFirstName { get; set; }
        [MaxLength(1)] //String of length 1 is easier than char for validation
        public string? BowlerMiddleInit { get; set; }
        [MaxLength(50)]
        public string? BowlerAddress { get; set; }
        [MaxLength(50)]
        public string? BowlerCity { get; set; }
        [MaxLength(2)]
        public string? BowlerState { get; set; }
        [MaxLength(50)]
        public string? BowlerZip { get; set; }
        [MaxLength(50)]
        public string? BowlerPhoneNumber { get; set; }
    }
}


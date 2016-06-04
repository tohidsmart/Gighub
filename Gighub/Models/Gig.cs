using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
	public class Gig
	{
		public int Id { get; set; }
		[Required]
		public ApplicationUser Artists { get; set; } 
		public DateTime DateTime { get; set; }
		[Required]
		[StringLength(255)]
		public string Venue { get; set; }
		public Genre Genre { get; set; }
	}

	
}
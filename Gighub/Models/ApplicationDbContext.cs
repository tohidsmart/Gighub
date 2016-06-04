using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Gighub.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Gig> Gigs { get; set; }
		public DbSet<Genre> Genres { get; set; }

		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}
	}
}
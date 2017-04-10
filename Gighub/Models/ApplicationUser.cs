using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gighub.Models
{
    using System.ComponentModel.DataAnnotations;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
	    [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsyn(UserManager<ApplicationUser> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			return userIdentity;
		}
	}
}
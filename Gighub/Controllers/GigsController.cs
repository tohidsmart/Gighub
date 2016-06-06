using Gighub.Models;
using Gighub.ViewModel;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{
	public class GigsController : Controller
	{
		private ApplicationDbContext _context;

		public GigsController()
		{
			_context=new ApplicationDbContext();
		}
		
		[Authorize]
		public ActionResult Create()
		{
			var model = new GigFormViewModel
			{
				Genres = _context.Genres.ToList()
			};
			
			return View(model);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Create(GigFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Genres = _context.Genres.ToList();
				return View("Create", model);
			}

			Gig gig =new Gig
			{
				ArtistId =User.Identity.GetUserId(),
				DateTime = model.GetDateTime(),
				GenreId= model.Genre,
				Venue =model.Venue
				

			};

			_context.Gigs.Add(gig);
			_context.SaveChanges();
			return RedirectToAction("Index","Home");

		}


	}
}
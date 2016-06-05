using Gighub.Models;
using Gighub.ViewModel;
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
		
		public ActionResult Create()
		{
			var model = new GigFormViewModel
			{
				Genres = _context.Genres.ToList()
			};
			
			return View(model);
		}


	}
}
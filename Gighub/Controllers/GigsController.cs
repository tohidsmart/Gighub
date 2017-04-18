using Gighub.Models;
using Gighub.ViewModel;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres.ToList();
                return View("Create", model);
            }
            Gig gig = new Gig
            {

                ArtistId = User.Identity.GetUserId(),
                DateTime = model.GetDateTime(),
                GenreId = model.Genre,
                Venue = model.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances.
                Where(a => a.AttendeeId == userId).Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre);
            var gigAttendingView = new GigViewModel
            {
                UpComingGigs = gigs,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View("Gigs", gigAttendingView);
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.Id == id).FirstOrDefault();
            GigDetailModel detailModel = new GigDetailModel
            {
                Gig = gig,
                IsAttending = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == id)
            };
            return View(detailModel);
        }

    }
}
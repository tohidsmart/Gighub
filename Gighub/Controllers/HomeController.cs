using System.Data.Entity;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    using Gighub.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModel;

    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
               .Where(g => g.DateTime > DateTime.Now);
            GigViewModel homeModel = new GigViewModel
            {
                UpComingGigs = upcomingGigs,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View("Gigs",homeModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
    }

    
}
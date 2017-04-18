using Gighub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gighub.ViewModel
{
    public class GigViewModel
    {
        public bool ShowAction { get; internal set; }
        public IEnumerable<Gig> UpComingGigs { get; set; }
    }

}
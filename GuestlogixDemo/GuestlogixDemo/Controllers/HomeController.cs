using GuestlogixDemo.Data;
using GuestlogixDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestlogixDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string origin = null, string destination = null, bool testMode = false)
        {
            IndexViewModel model = new IndexViewModel();
            if(origin == null || destination == null)
            {
                return View(model);
            }
            model.Origin = origin;
            model.Destination = destination;
            model.Mode = testMode;
            model.Result = new DataAccess().GetShortestPath(origin, destination, testMode);
           
            return View(model);
        }

    }
}
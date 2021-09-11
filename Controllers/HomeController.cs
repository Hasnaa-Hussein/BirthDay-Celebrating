using Birthday_Celebrating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Birthday_Celebrating.Controllers
{
    public class HomeController : Controller
    {
        private TBLChildernEntities db = new TBLChildernEntities();

        // GET: TblChilderns
        public ActionResult Index()
        {
            ViewBag.db = db;
            return View(db.TblChilderns.ToList());
        }

        public ActionResult Add(int id)
        {
            var x = db.TblChilderns.Find(id);
            x.Attend = true;
            db.SaveChanges();
            string day = DateTime.Today.ToString("MM/dd");
            string birth = x.BirthDate?.ToString("MM/dd");
            if (day == birth)
            {
                TempData["birthtoday"] = "hello";
            }

            return RedirectToAction("index", TempData["birthtoday"]);
        }

        public ActionResult Remove(int ID)
        {
            TblChildern x = db.TblChilderns.Find(ID);
            x.Attend = false;
            //x.Today = false;
            db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
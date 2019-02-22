using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElementwareCommesse.Models;

namespace ElementwareCommesse.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult ConfiguraSezioni()
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            int ID = 0;
            foreach(var IDSez in DB.TAB_SEZ)
            {
                ID = IDSez.IDSez;
            }

            ID++;

            var SEZ = new TAB_SEZ();

            SEZ.IDSez = ID;
            
            return View(SEZ);
        }

        [HttpPost]
        public ActionResult ConfiguraSezioni(TAB_SEZ SEZ)
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            if (ModelState.IsValid) { 

            DB.TAB_SEZ.Add(SEZ);
            DB.SaveChanges();
            }

            return View();
        }

}
}
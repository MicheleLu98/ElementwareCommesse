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
        int ID;

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



        public ActionResult ScegliOperazione()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfiguraSezioni()
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            foreach(var IDSez in DB.TAB_SEZ)
            {
                ID = IDSez.IDSez;
            }

            ID = ID + 1;

            var SEZ = new TAB_SEZ();

            SEZ.IDSez = ID;

            
            
            return View(SEZ);
        }

        [HttpPost]
        public ActionResult ConfiguraSezioni(TAB_SEZ SEZ)
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            foreach (var IDSez in DB.TAB_SEZ)
            {
                ID = IDSez.IDSez;
            }

            ID = ID + 1;
            if (ModelState.IsValid) {
                SEZ.IDSez = ID;
                DB.TAB_SEZ.Add(SEZ);
                DB.SaveChanges();
            }

            return RedirectToAction("ConfiguraSezioni","Home");
        }


        [HttpGet]
        public ActionResult SelezionaSezioni()
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
           
            
            SezioniModel sezioniModel = new SezioniModel();

            sezioniModel.SEZs = DB.TAB_SEZ.ToList<TAB_SEZ>();
            return View(sezioniModel);
            
           
           
        }



        [HttpPost]
        public ActionResult SelezionaSezioni(SezioniModel SezModel)
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            var SelectedSez = SezModel.SEZs.Where(x => x.IsChecked == true).ToList<TAB_SEZ>();

            TAB_CONFIGURAZIONE_SEZIONI TBConfSez;

            foreach(var item in SelectedSez)
            {
                TBConfSez = new TAB_CONFIGURAZIONE_SEZIONI();
                TBConfSez.IDSez = item.IDSez;
                TBConfSez.NomeSezione = item.NomeSezione;
                if (Session["IDConfigurazione"] != null)
                    TBConfSez.IDConfigurazione = int.Parse(Session["IDConfigurazione"].ToString());
                else
                    TBConfSez.IDConfigurazione = 0;
                DB.TAB_CONFIGURAZIONE_SEZIONI.Add(TBConfSez);
                DB.SaveChanges();
            }

           return RedirectToAction("ConfiguraColonne");
        }



        [HttpGet]
        public ActionResult ConfiguraColonne()
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            CombinedModel obj = new CombinedModel();


            if (Session["ISUsingConfig"] == null)
            {
                Session["ISUsingConfig"] = false;
                
            }

            int IDConf = int.Parse(Session["IDConfigurazione"].ToString());

            if (bool.Parse(Session["ISUsingConfig"].ToString()))
            {
                obj.ColonneModel = new TAB_COLONNE();
                var cf = DB.TAB_CONFIGURAZIONE_SEZIONI.Where(x => x.IDConfigurazione == IDConf).ToList();

                obj.ColonneModel.IDlist = new SelectList(cf, "IDSez", "IDSez");

                return View(obj);
            }
            else
            {
                obj.ColonneModel = new TAB_COLONNE();
                obj.ColonneModel.IDlist = new SelectList(DB.TAB_SEZ, "IDSez", "IDSez");
                return View(obj);
            }


            
           
        }

        [HttpPost]
        public ActionResult ConfiguraColonne([Bind(Exclude = "IDSezioneProp,IDlist")]CombinedModel obj)
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();

            foreach (var IDSez in DB.TAB_COLONNE)
            {
                ID = IDSez.IDColonna;
            }

            ID = ID + 1;


            if(DB.TAB_COLONNE.Count().Equals(0))
            {
                ID = 0;
            }

            obj.ColonneModel.IDSez = obj.SezModel.IDSez;
            obj.ColonneModel.IDColonna = ID;

            if (ModelState.IsValid)
            {
                DB.TAB_COLONNE.Add(obj.ColonneModel);
                DB.SaveChanges();
            }

            return RedirectToAction("ConfiguraColonne", "Home");
        }


        //public ActionResult addConfig()
        //{
        //    DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();

        //    ID = 0;
        //    if (!DB.TAB_CONFIGURAZIONE.Count().Equals(0))
        //    {
        //        foreach (var i in DB.TAB_CONFIGURAZIONE)
        //        {
        //            ID = i.IDConfigurazione;
        //        }
        //        ID++;
        //    }

        //    TAB_CONFIGURAZIONE TabConf = new TAB_CONFIGURAZIONE();
        //    TabConf.IDConfigurazione = ID;
        //    TabConf.NomeConfigurazione = "";
        //    TabConf.DescrizioneCofigurazione = "";
        //    DB.TAB_CONFIGURAZIONE.Add(TabConf);
        //    DB.SaveChanges();

        //    TAB_CONFIGURAZIONE_SEZIONI TabCS = new TAB_CONFIGURAZIONE_SEZIONI();

           



        //    var Table = DB.TAB_COLONNE;
        //    var NidMax = from Col in Table
        //                 select new { Col.IDSez };

        //    var ListIDSez = new List<int>(); 
        //    IQueryable<TAB_COLONNE>[] listColonne = new IQueryable<TAB_COLONNE>[NidMax.Count()];
        //    for (int i = 0; i < NidMax.Count(); i++)
        //    {

        //        var Query2 = from Col in Table
        //                     select Col;

        //        Query2 = Query2.Where(c => c.IDSez == i);
        //        foreach (var ii in Query2)
        //        {
        //            TabCS.IDConfigurazione = ID;
        //            if (!ListIDSez.Contains(ii.IDSez))
        //            {
        //                ListIDSez.Add(ii.IDSez);
        //                TabCS.IDSez = ii.IDSez;
        //            }

        //            DB.TAB_CONFIGURAZIONE_SEZIONI.Add(TabCS);
        //            DB.SaveChanges();
        //        }
        //    }

           



        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult AggiungiConfig()
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();

            ID = 0;
            if (!DB.TAB_CONFIGURAZIONE.Count().Equals(0))
            {
                foreach (var i in DB.TAB_CONFIGURAZIONE)
                {
                    ID = i.IDConfigurazione;
                }
                ID++;
            }

            TAB_CONFIGURAZIONE TB = new TAB_CONFIGURAZIONE();
            TB.IDConfigurazione = ID;
            Session["IDConfigurazione"] = ID;
            Session["ISUsingConfig"] = true;
            return View(TB);
        }


        [HttpPost]
        public ActionResult AggiungiConfig(TAB_CONFIGURAZIONE TB)
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();


            TB.IDConfigurazione = int.Parse(Session["IDConfigurazione"].ToString());

            DB.TAB_CONFIGURAZIONE.Add(TB);
            DB.SaveChanges();

            return RedirectToAction("ConfiguraSezioni");
        }

        [HttpGet]
        public ActionResult CreteDOC()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreteDOC(RowMODEL tb)
        {
            DBElementwareCommesseEntities DB = new DBElementwareCommesseEntities();
            if(DB.TAB_ROW.Count() == 0)
            {
                foreach (var i in tb.FormSet)
                {
                    i.IDRow = 0;
                }
            }
            else
            {
                ID = 0;
                foreach (var i in tb.FormSet)
                {
                    ID = i.IDRow;
                }
                ID++;
                
            }



            foreach (var i in tb.FormSet)
            {
                i.IDRow = ID;
                DB.TAB_ROW.Add(i);
                DB.SaveChanges();
            }

            return View();
        }

    }


}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSurvey;
using StoreSurvey.helpers;

namespace StoreSurvey.Controllers
{ 
    public class BasicWaveDisplayController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;

        //
        // GET: /BasicWaveDisplay/

        public ViewResult Index()
        {
            return View(db.WaveDisplayBasics.ToList());
        }

        //
        // GET: /BasicWaveDisplay/Details/5

        public ViewResult Details(int id)
        {
            WaveDisplayBasic wavedisplaybasic = db.WaveDisplayBasics.Find(id);
            return View(wavedisplaybasic);
        }

        //
        // GET: /BasicWaveDisplay/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BasicWaveDisplay/Create

        [HttpPost]
        public ActionResult Create(WaveDisplayBasic wavedisplaybasic)
        {
            if (ModelState.IsValid)
            {
                db.WaveDisplayBasics.Add(wavedisplaybasic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(wavedisplaybasic);
        }
        
        //
        // GET: /BasicWaveDisplay/Edit/5
 
        public ActionResult Edit(int id)
        {
            WaveDisplayBasic wavedisplaybasic = db.WaveDisplayBasics.Find(id);
            return View(wavedisplaybasic);
        }

        //
        // POST: /BasicWaveDisplay/Edit/5

        [HttpPost]
        public ActionResult Edit(WaveDisplayBasic wavedisplaybasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wavedisplaybasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wavedisplaybasic);
        }

        //
        // GET: /BasicWaveDisplay/Delete/5
 
        public ActionResult Delete(int id)
        {
            WaveDisplayBasic wavedisplaybasic = db.WaveDisplayBasics.Find(id);
            return View(wavedisplaybasic);
        }

        //
        // POST: /BasicWaveDisplay/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            WaveDisplayBasic wavedisplaybasic = db.WaveDisplayBasics.Find(id);
            db.WaveDisplayBasics.Remove(wavedisplaybasic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
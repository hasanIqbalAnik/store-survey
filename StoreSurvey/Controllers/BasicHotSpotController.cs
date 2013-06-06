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
    public class BasicHotSpotController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;

        //
        // GET: /BasicHotSpot/

        public ViewResult Index()
        {
            return View(db.HotSpotBasics.ToList());
        }

        //
        // GET: /BasicHotSpot/Details/5

        public ViewResult Details(int id)
        {
            HotSpotBasic hotspotbasic = db.HotSpotBasics.Find(id);
            return View(hotspotbasic);
        }

        //
        // GET: /BasicHotSpot/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BasicHotSpot/Create

        [HttpPost]
        public ActionResult Create(HotSpotBasic hotspotbasic)
        {
            if (ModelState.IsValid)
            {
                db.HotSpotBasics.Add(hotspotbasic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(hotspotbasic);
        }
        
        //
        // GET: /BasicHotSpot/Edit/5
 
        public ActionResult Edit(int id)
        {
            HotSpotBasic hotspotbasic = db.HotSpotBasics.Find(id);
            return View(hotspotbasic);
        }

        //
        // POST: /BasicHotSpot/Edit/5

        [HttpPost]
        public ActionResult Edit(HotSpotBasic hotspotbasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotspotbasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotspotbasic);
        }

        //
        // GET: /BasicHotSpot/Delete/5
 
        public ActionResult Delete(int id)
        {
            HotSpotBasic hotspotbasic = db.HotSpotBasics.Find(id);
            return View(hotspotbasic);
        }

        //
        // POST: /BasicHotSpot/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            HotSpotBasic hotspotbasic = db.HotSpotBasics.Find(id);
            db.HotSpotBasics.Remove(hotspotbasic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
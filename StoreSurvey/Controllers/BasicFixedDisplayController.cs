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
    public class BasicFixedDisplayController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;

        //
        // GET: /BasicFixedDisplay/

        public ViewResult Index()
        {
          return View(db.FixedDisplayBasics.ToList());
        }

        //
        // GET: /BasicFixedDisplay/Details/5

        public ViewResult Details(int id)
        {
            FixedDisplayBasic fixeddisplaybasic = db.FixedDisplayBasics.Find(id);
            return View(fixeddisplaybasic);
        }

        //
        // GET: /BasicFixedDisplay/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BasicFixedDisplay/Create

        [HttpPost]
        public ActionResult Create(FixedDisplayBasic fixeddisplaybasic)
        {
            if (ModelState.IsValid)
            {
                db.FixedDisplayBasics.Add(fixeddisplaybasic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fixeddisplaybasic);
        }
        
        //
        // GET: /BasicFixedDisplay/Edit/5
 
        public ActionResult Edit(int id)
        {
            FixedDisplayBasic fixeddisplaybasic = db.FixedDisplayBasics.Find(id);
            return View(fixeddisplaybasic);
        }

        //
        // POST: /BasicFixedDisplay/Edit/5

        [HttpPost]
        public ActionResult Edit(FixedDisplayBasic fixeddisplaybasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixeddisplaybasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fixeddisplaybasic);
        }

        //
        // GET: /BasicFixedDisplay/Delete/5
 
        public ActionResult Delete(int id)
        {
            FixedDisplayBasic fixeddisplaybasic = db.FixedDisplayBasics.Find(id);
            return View(fixeddisplaybasic);
        }

        //
        // POST: /BasicFixedDisplay/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            FixedDisplayBasic fixeddisplaybasic = db.FixedDisplayBasics.Find(id);
            db.FixedDisplayBasics.Remove(fixeddisplaybasic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

 
    }
}
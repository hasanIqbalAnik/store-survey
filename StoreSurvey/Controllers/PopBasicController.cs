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
    public class PopBasicController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;

        //
        // GET: /PopBasic/

        public ViewResult Index()
        {
            return View(db.POPBasics.ToList());
        }

        //
        // GET: /PopBasic/Details/5

        public ViewResult Details(int id)
        {
            POPBasic popbasic = db.POPBasics.Find(id);
            return View(popbasic);
        }

        //
        // GET: /PopBasic/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PopBasic/Create

        [HttpPost]
        public ActionResult Create(POPBasic popbasic)
        {
            if (ModelState.IsValid)
            {
                db.POPBasics.Add(popbasic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(popbasic);
        }
        
        //
        // GET: /PopBasic/Edit/5
 
        public ActionResult Edit(int id)
        {
            POPBasic popbasic = db.POPBasics.Find(id);
            return View(popbasic);
        }

        //
        // POST: /PopBasic/Edit/5

        [HttpPost]
        public ActionResult Edit(POPBasic popbasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(popbasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(popbasic);
        }

        //
        // GET: /PopBasic/Delete/5
 
        public ActionResult Delete(int id)
        {
            POPBasic popbasic = db.POPBasics.Find(id);
            return View(popbasic);
        }

        //
        // POST: /PopBasic/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            POPBasic popbasic = db.POPBasics.Find(id);
            db.POPBasics.Remove(popbasic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
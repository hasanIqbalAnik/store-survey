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
    public class BasicSkusController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;

        //
        // GET: /BasicSkus/

        public ViewResult Index()
        {
            return View(db.MustHaveSkusBasics.ToList());
        }

        //
        // GET: /BasicSkus/Details/5

        public ViewResult Details(int id)
        {
            MustHaveSkusBasic musthaveskusbasic = db.MustHaveSkusBasics.Find(id);
            return View(musthaveskusbasic);
        }

        //
        // GET: /BasicSkus/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BasicSkus/Create

        [HttpPost]
        public ActionResult Create(MustHaveSkusBasic musthaveskusbasic)
        {
            if (ModelState.IsValid)
            {
                db.MustHaveSkusBasics.Add(musthaveskusbasic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(musthaveskusbasic);
        }
        
        //
        // GET: /BasicSkus/Edit/5
 
        public ActionResult Edit(int id)
        {
            MustHaveSkusBasic musthaveskusbasic = db.MustHaveSkusBasics.Find(id);
            return View(musthaveskusbasic);
        }

        //
        // POST: /BasicSkus/Edit/5

        [HttpPost]
        public ActionResult Edit(MustHaveSkusBasic musthaveskusbasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musthaveskusbasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musthaveskusbasic);
        }

        //
        // GET: /BasicSkus/Delete/5
 
        public ActionResult Delete(int id)
        {
            MustHaveSkusBasic musthaveskusbasic = db.MustHaveSkusBasics.Find(id);
            return View(musthaveskusbasic);
        }

        //
        // POST: /BasicSkus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            MustHaveSkusBasic musthaveskusbasic = db.MustHaveSkusBasics.Find(id);
            db.MustHaveSkusBasics.Remove(musthaveskusbasic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

   
    }
}
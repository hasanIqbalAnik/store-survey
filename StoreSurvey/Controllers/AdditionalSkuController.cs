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
    public class AdditionalSkuController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;

        //
        // GET: /AdditionalSku/

        public ViewResult Index()
        {
            return View(db.AdditionalSkuBasics.ToList());
        }

        //
        // GET: /AdditionalSku/Details/5

        public ViewResult Details(int id)
        {
            AdditionalSkuBasic additionalskubasic = db.AdditionalSkuBasics.Find(id);
            return View(additionalskubasic);
        }

        //
        // GET: /AdditionalSku/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdditionalSku/Create

        [HttpPost]
        public ActionResult Create(AdditionalSkuBasic additionalskubasic)
        {
            if (ModelState.IsValid)
            {
                db.AdditionalSkuBasics.Add(additionalskubasic);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(additionalskubasic);
        }
        
        //
        // GET: /AdditionalSku/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdditionalSkuBasic additionalskubasic = db.AdditionalSkuBasics.Find(id);
            return View(additionalskubasic);
        }

        //
        // POST: /AdditionalSku/Edit/5

        [HttpPost]
        public ActionResult Edit(AdditionalSkuBasic additionalskubasic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionalskubasic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additionalskubasic);
        }

        //
        // GET: /AdditionalSku/Delete/5
 
        public ActionResult Delete(int id)
        {
            AdditionalSkuBasic additionalskubasic = db.AdditionalSkuBasics.Find(id);
            return View(additionalskubasic);
        }

        //
        // POST: /AdditionalSku/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AdditionalSkuBasic additionalskubasic = db.AdditionalSkuBasics.Find(id);
            db.AdditionalSkuBasics.Remove(additionalskubasic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult testJson()
        {
            //return Json("[{'custId':7,"cookieNum":"","emailId":"raju.allen1888@gmail.com","facebookId":"","twitterId":"","gmailId":"","mobilePhone":""},{"custId":8,"cookieNum":"","emailId":"raju@gmail.com","facebookId":"","twitterId":"","gmailId":"","mobilePhone":""}]", JsonRequestBehavior.AllowGet)

            return Json(new{custId = "7",cookieNum = "",emailId = "raju.allen1888@gmail.com"}, JsonRequestBehavior.AllowGet);

            
        }


        
    }
}
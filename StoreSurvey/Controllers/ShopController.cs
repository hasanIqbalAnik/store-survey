using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSurvey;
using StoreSurvey.Implementations;
using StoreSurvey.helpers;

using PagedList;
namespace StoreSurvey.Controllers
{ 
    public class ShopController : Controller
    {
        private StoreSurveyEntities db = ShopSingleton.Instance._db;
        ImplShopService shopService = new ImplShopService();
        //
        // GET: /Shop/
        string regionFilterString = null;
        string townFilterString = null;
        string territoryFilterString = null;
        string dmsCodeFilterString = null;

        public ViewResult Index(string regionFilter, string townFilter, string territoryFilter, string dmsCodeFilter, int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }


            regionFilterString = regionFilter;
            townFilterString = townFilter;
            territoryFilterString = territoryFilter;
            dmsCodeFilterString = dmsCodeFilter;

            ViewBag.regionFilter = regionFilter ;
            ViewBag.townFilter = townFilter;
            ViewBag.territoryFilter = territoryFilter;
            ViewBag.dmsCodeFilter = dmsCodeFilter;

            
            var students = db.Shops.OrderBy(m => m.id).Take(6000);
            if (!String.IsNullOrEmpty(regionFilterString))
            {
                students = students.Where(s => s.Region.ToUpper().Contains(regionFilterString.ToUpper()));
            }

            if (!String.IsNullOrEmpty(townFilterString))
            {
                students = students.Where(s => s.Town.ToUpper().Contains(townFilterString.ToUpper()));
            }
            if (!String.IsNullOrEmpty(territoryFilterString))
            {
                students = students.Where(s => s.Territory.ToUpper().Contains(territoryFilterString.ToUpper()));
            }
            if (!String.IsNullOrEmpty(dmsCodeFilterString))
            {
                students = students.Where(s => s.DMS_CODE.ToUpper().Contains(dmsCodeFilterString.ToUpper()));
            }

            
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Shop/Details/5

        public ViewResult Details(int id)
        {
            Shop shop = db.Shops.Find(id);
            return View(shop);
        }

        //
        // GET: /Shop/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Shop/Create

        [HttpPost]
        public ActionResult Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(shop);
        }
        
        //
        // GET: /Shop/Edit/5
 
        public ActionResult Edit(int id)
        {
            Shop shop = db.Shops.Find(id);
            return View(shop);
        }

        //
        // POST: /Shop/Edit/5

        [HttpPost]
        public ActionResult Edit(Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        //
        // GET: /Shop/Delete/5
 
        public ActionResult Delete(int id)
        {
            Shop shop = db.Shops.Find(id);
            return View(shop);
        }

        //
        // POST: /Shop/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
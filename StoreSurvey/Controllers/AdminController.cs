﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSurvey;
using StoreSurvey.Implementations;

namespace StoreSurvey.Controllers
{ 
    public class AdminController : Controller
    {
        private StoreSurveyEntities db = new StoreSurveyEntities();
        private ImplUserService userService = new ImplUserService();
        //
        // GET: /Admin/

        public ViewResult Index()
        {
            var users = db.Users.Include("Role");
            return View(users.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ViewResult Details(int id)
        {
            User user = db.Users.Single(u => u.ID == id);
            return View(user);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name");
            return View();
        } 

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                this.userService.CreateUser(user);
                return RedirectToAction("Index");  
            }

            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            return View(user);
        }
        
        //
        // GET: /Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = this.userService.UpdateUser(userService.GetUserById(id));
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            return View(user);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
           
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            return View(user);
        }

        //
        // GET: /Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = db.Users.Single(u => u.ID == id);
            return View(user);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            //User user = db.Users.Single(u => u.ID == id);
            //db.Users.DeleteObject(user);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
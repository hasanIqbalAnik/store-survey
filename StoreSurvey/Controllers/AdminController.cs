﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSurvey;
using StoreSurvey.Implementations;
using System.IO;
using NLog;
using StoreSurvey.helpers;

namespace StoreSurvey.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private StoreSurveyEntities db = ShopSingleton.Instance._db;
        private ImplUserService userService = new ImplUserService();
        //
        // GET: /Admin/

        public ViewResult Index()
        {
            
            var users = db.Users.Include("Role").Where(u=> u.Active.Value==1);
            return View(users.ToList());
        }
        public ActionResult LockedUsers() 
        {
            var users = db.Users.Include("Role").Where(u => u.Active.Value == 0);
            return View(users.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ViewResult Details(int id)
        {
            User user = db.Users.Single(u => u.id == id);
            return View(user);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "id", "Name");
            return View();
        } 

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid && this.userService.CheckDuplicate(user) == false)
            {
                this.userService.CreateUser(user);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty,"Username or Email is taken. They should be uniuqe.");
            ViewBag.RoleID = new SelectList(db.Roles, "id", "Name", user.RoleID);
            return View(user);
        }
        
        //
        // GET: /Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = this.userService.UpdateUser(userService.GetUserById(id));
            ViewBag.RoleID = new SelectList(db.Roles, "id", "Name", user.RoleID);
            return View(user);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            this.userService.UpdateUser(user);
            ViewBag.RoleID = new SelectList(db.Roles, "id", "Name", user.RoleID);
            return View(user);
        }

        //
        // GET: /Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = db.Users.Single(u => u.id == id);
            return View(user);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            //User user = db.Users.Single(u => u.id == id);
            //db.Users.DeleteObject(user);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LockUser(string userId) 
        {
            this.userService.LockUser(Convert.ToInt32(userId));
            return RedirectToAction("Index");
        }

        public ActionResult UnLockUser(string userId)
        {
            this.userService.UnLockUser(Convert.ToInt32(userId));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FileUpload() {
            return View();
        }

        // This action handles the form POST and the upload
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            //    HttpPostedFileBase file = Request.Files[i]; //Uploaded file
            //    //Use the following properties to get file's name, size and MIMEType
            //    int fileSize = file.ContentLength;
            //    string fileName = file.FileName;
            //    string mimeType = file.ContentType;
            //    System.IO.Stream fileContent = file.InputStream;
            //    //To save file, use SaveAs method
            //    file.SaveAs(Server.MapPath("~/uploads/") + fileName); //File will be saved in application root
            //}

            
             
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            ViewBag.sucessOrError = "File uploaded sucessfully";

            return View();
        }




    }
}
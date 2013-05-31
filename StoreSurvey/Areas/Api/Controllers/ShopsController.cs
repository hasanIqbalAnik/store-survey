using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSurvey.Areas.Api.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;


namespace StoreSurvey.Areas.Api.Controllers
{
    public class ShopsController : Controller
    {

        IShopsManager shopsManager;

        public ShopsController()
        {
            this.shopsManager = new ImplShopsManager();

        }

        //[HttpGet]
        //public ActionResult ShopsList()
        //{
        //    System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath("~/downloads/test.txt"));
                     
            
        //    var serializer = new JavaScriptSerializer();
            
        //    MemoryStream memoryStream = new MemoryStream();
        //    TextWriter tw = new StreamWriter(memoryStream);

        //    var shopList = shopsManager.GetAllShops();
            
        //    for (int i = 0; i < shopList.Count; i++)
        //    {
        //        //jsResult = jsResult +  serializer.Serialize(shopList[i]);
        //        file.Write(serializer.Serialize(shopList[i]));
        //        tw.Write(serializer.Serialize(shopList[i]));
        //    }

        //    file.Close();
        //    tw.Flush();
        //    tw.Close();

        //    return File(memoryStream.GetBuffer(), "text/plain", "file.txt");
        //    //return Json(jsResult, JsonRequestBehavior.AllowGet);

        //}

        [HttpGet]
        public ActionResult ShopsList(String shopInfoFilePath)
        {
            this.shopsManager.PostAllShops();
            return View();
        }

    }
}

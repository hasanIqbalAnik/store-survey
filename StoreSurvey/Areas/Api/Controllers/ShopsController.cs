using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreSurvey.Areas.Api.Models;
using System.Web.Script.Serialization;

namespace StoreSurvey.Areas.Api.Controllers
{
    public class ShopsController : Controller
    {

        IShopsManager shopsManager;

        public ShopsController()
        {
            this.shopsManager = new ImplShopsManager();

        }

        [HttpGet]
        public JsonResult ShopsList()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath("~/downloads/test.txt"));
            

            

            string jsResult = null;
            var serializer = new JavaScriptSerializer();

            var shopList = shopsManager.GetAllShops();
            for (int i = 0; i < shopList.Count; i++)
            {
                //jsResult = jsResult +  serializer.Serialize(shopList[i]);
                file.Write(serializer.Serialize(shopList[i]));
}

            file.Close();
            //return Json(jsResult, JsonRequestBehavior.AllowGet);
            return null;
        }
    }
}

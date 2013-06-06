using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using StoreSurvey.Areas.Api.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;


namespace StoreSurvey.Areas.Api.Controllers
{
    public class ShopsController : Controller
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        IShopsManager shopsManager;

        public ShopsController()
        {
            this.shopsManager = new ImplShopsManager();

        }

        [HttpGet]
        public ActionResult ShopsList(int? pageNum, int? chunkSize)
        {
            
        //    var file = new System.IO.StreamWriter(Server.MapPath("~/downloads/test.txt"));

            
            var serializer = new JavaScriptSerializer();
            #region unused memoryStream declaration
            
            //var memoryStream = new MemoryStream();
            //TextWriter tw = new StreamWriter(memoryStream);
            #endregion

            var shopList = shopsManager.GetAllShops();
            
            var collection = shopList.Select(x => new
            {
                id = x.Id,
               // SLNO = x.SLNO,
                region = x.Region,
                territory = x.Territory,
                town = x.Town,
                //ShopName = x.ShopName,
                //ShopAddress = x.ShopAddress,
                shopType= x.ShopType,
                //SLAB  = x.SLAB,
                //Phon = x.Phon,
                dmsCode = x.DMS_CODE
                #region unused questionnaires
                
                //Questionnaires = x.Questionnaires.Select(item => new
                //{
                //    Id = item.Id,
                //    shopId = item.shopId,
                //    name = item.name,
                //    date = item.date,
                //    cellNo = item.cellNo,
                //    imageUrl1 = item.imageUrl1,
                //    imageUrl2 = item.imageUrl2,
                //    latitude = item.latitude,
                //    longitude = item.longitude,
                //    formId = item.formId
                //})
                #endregion
            });

           if(pageNum != null && chunkSize != null) collection = collection.Take(pageNum.Value * chunkSize.Value).Skip((pageNum.Value - 1) * (chunkSize.Value));
            
            #region unused file writing
            
            //foreach (var t in collection)
            //{

            //    file.Write(serializer.Serialize(t));
            //    tw.Write(serializer.Serialize(t));
            //}

            //file.Close();
            //tw.Flush();
            //tw.Close();

            //return File(memoryStream.GetBuffer(), "text/plain", "file.txt");
            #endregion

            serializer.MaxJsonLength = Int32.MaxValue;
            log.Debug("setting serializer value to " + Int32.MaxValue);
            log.Debug("test line again");
      
            return new ContentResult
            {
                Content = serializer.Serialize(collection),
                ContentType = "application/json"
            };
            //log.Debug("result string size after serialization: " + result.Content.Length);
            //return result;
      

        }

        //[HttpGet]
        //public ActionResult ShopsList(String shopInfoFilePath)
        //{
        //    this.shopsManager.PostAllShops();
        //    return View();
        //}

    }
}

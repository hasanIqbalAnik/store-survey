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
        private JavaScriptSerializer serializer;
        IShopsManager shopsManager;

        public ShopsController()
        {
            serializer = new JavaScriptSerializer();
            this.shopsManager = new ImplShopsManager();

        }

        [HttpGet]
        public ActionResult GetShopCount()
        {
            return Json(shopsManager.GetAllShops().Count, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShopsList(int? pageNum, int? chunkSize)
        {

            //    var file = new System.IO.StreamWriter(Server.MapPath("~/downloads/test.txt"));



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
                shopType = x.ShopType,
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

            if (pageNum != null && chunkSize != null) collection = collection.Take(pageNum.Value * chunkSize.Value).Skip((pageNum.Value - 1) * (chunkSize.Value));

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



        }

        #region mustHaveSkuCRUD

        [HttpGet]
        public ActionResult MustHaveSkus()
        {
            return new ContentResult
         {
             Content = serializer.Serialize(this.shopsManager.GetAllMustHaveSkus()),
             ContentType = "application/json"
         };


        }

        [HttpPost]
        public  ActionResult MustHaveSkus(List<MustHaveSku> listOfSkus)
        {
            this.shopsManager.PostAllMustHaveSkus(listOfSkus);
            return Json("Added skus successfully", JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult MustHaveSkusBasic()
        {
            return new ContentResult
            {
                Content = serializer.Serialize(this.shopsManager.GetAllMustHaveSkusBasic()),
                ContentType = "application/json"
            };
        }

        [HttpPost]
        public ActionResult MustHaveSkusBasic(List<MustHaveSkusBasic> list )
        {
            this.shopsManager.PostAllMustHaveSkusBasic(list);
            return Json("Added Basic skus successfully", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FixedDisplayBasic
        [HttpGet]
        public ActionResult FixedDisplayBasics()
        {
            return new ContentResult
            {
                Content = serializer.Serialize(this.shopsManager.GetAllFixedDisplayBasic()),
                ContentType = "application/json"
            };
        }
        #endregion

        #region WaveDisplays
        [HttpGet]
        public ActionResult WaveDisplayBasics()
        {
            return new ContentResult
            {
                Content = serializer.Serialize(this.shopsManager.GetAllWaveDisplayBasic()),
                ContentType = "application/json"
            };
        }
        #endregion
        #region hot spot basics
        [HttpGet]
        public ActionResult HotSpotBasics()
        {
            return new ContentResult
            {
                Content = serializer.Serialize(this.shopsManager.GetAllHotSpotBasic()),
                ContentType = "application/json"
            };
        }
        #endregion

        #region PopBasics
        [HttpGet]
        public  ActionResult POPBasics()
        {
            return new ContentResult
            {
                Content = serializer.Serialize(this.shopsManager.GetAllPopBasic()),
                ContentType = "application/json"
            };
        }
        #endregion

        #region additional sku basic
        [HttpGet]
        public ActionResult AdditionalSkuBasics()
        {
            return new ContentResult
            {
                Content = serializer.Serialize(this.shopsManager.GetAllAdditionalSkuBasic()),
                ContentType = "application/json"
            };
        }
        #endregion

    }
}


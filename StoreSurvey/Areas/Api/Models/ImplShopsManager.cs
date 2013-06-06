using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreSurvey.Helpers;
using System.IO;


namespace StoreSurvey.Areas.Api.Models
{
    public class ImplShopsManager : IShopsManager
    {
        private StoreSurveyEntities _db = new StoreSurveyEntities();


        List<Shop> IShopsManager.GetAllShops()
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var region = (string)HttpContext.Current.Session["region"];
            var shopList = (from m in this._db.Shops
                            //where m.Region == region
                            select m).ToList();
            return shopList;
        }

        List<Shop> IShopsManager.PostAllShops()
        {
            var filePath = HttpContext.Current.Server.MapPath("~/uploads/costing_ver1.xls");
            List<Shop> allShops = ExcellHelper.ReadFile(filePath);
            ExcellHelper exH = new ExcellHelper();

            return null;
        }

        Shop IShopsManager.GetShopById(int shopId)
        {
            
            throw new NotImplementedException();
        }

        Shop IShopsManager.PostShopById(Shop shop)
        {
            throw new NotImplementedException();
        }

        Shop IShopsManager.PutShop(Shop shop)
        {
            throw new NotImplementedException();
        }
    }
}
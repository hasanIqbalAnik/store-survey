using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreSurvey.Areas.Api.Models
{
    public class ImplShopsManager : IShopsManager
    {
        private StoreSurveyEntities _db = new StoreSurveyEntities();


        List<Shop> IShopsManager.GetAllShops()
        {
            var region = (string)HttpContext.Current.Session["region"];
            var shopList = (from m in this._db.Shops
                            //where m.Region == region
                            select m).ToList();
            return shopList;
        }

        List<Shop> IShopsManager.PostAllShops()
        {
            throw new NotImplementedException();
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
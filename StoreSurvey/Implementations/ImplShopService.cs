using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreSurvey.Interfaces;
using StoreSurvey.helpers;
namespace StoreSurvey.Implementations
{
    public class ImplShopService : IShopService
    {

        ShopSingleton shopSingle = ShopSingleton.Instance;
        

        public List<Shop> GetAllShops()
        {
            return shopSingle._db.Shops.ToList();
            
        }
        public Shop GetShopById(int shopId)
        {
            var shop = (from m in shopSingle._db.Shops
                       where m.Id == shopId
                        select m).FirstOrDefault() ;
            return shop;
        }
        public List<Shop> TakeNShops(int n) {
            return (shopSingle._db.Shops.ToList().OrderBy(x => x.Id).Take(n)).ToList();
        }
        public List<Shop> TakeNShopsAfterX(int n, int x){
        var shopsList = (from m in shopSingle._db.Shops
                        where m.Id > x 
                        orderby m.Id
                        select m).ToList();
            return shopsList;
        }


    }
}
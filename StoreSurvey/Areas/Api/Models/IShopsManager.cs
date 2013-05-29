using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSurvey.Areas.Api.Models
{
    interface IShopsManager
    {
        List<Shop> GetAllShops();
        List<Shop> PostAllShops();

        Shop GetShopById(int shopId);
        Shop PostShopById(Shop shop);

        Shop PutShop(Shop shop);
    }
}

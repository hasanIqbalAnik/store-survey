using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreSurvey.Interfaces
{
    public interface IShopService
    {
        List<Shop> GetAllShops();
        Shop GetShopById(int shopId);
        List<Shop> TakeNShops(int n);
        List<Shop> TakeNShopsAfterX(int n, int x);
    }
}
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

        List<MustHaveSku> GetAllMustHaveSkus();
        void PostAllMustHaveSkus(List<MustHaveSku> list);

        List<MustHaveSkusBasic> GetAllMustHaveSkusBasic();
        void PostAllMustHaveSkusBasic(List<MustHaveSkusBasic> list);

        List<FixedDisplayBasic> GetAllFixedDisplayBasic();
        List<WaveDisplayBasic> GetAllWaveDisplayBasic();
        List<HotSpotBasic> GetAllHotSpotBasic();
        List<POPBasic> GetAllPopBasic();
        List<AdditionalSkuBasic> GetAllAdditionalSkuBasic();

    }
}

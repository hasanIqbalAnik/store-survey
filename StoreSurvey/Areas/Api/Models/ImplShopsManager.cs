using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using StoreSurvey.Helpers;
using System.IO;


namespace StoreSurvey.Areas.Api.Models
{
    public class ImplShopsManager : IShopsManager
    {
        private StoreSurveyEntities _db = new StoreSurveyEntities();
        private static Logger log = LogManager.GetCurrentClassLogger();

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

        public List<MustHaveSku> GetAllMustHaveSkus()
        {
            var list = (from m in this._db.MustHaveSkus
                        select m).ToList();
            log.Debug("mustHaveSkus count to save in list: "+list.Count);
            return list;
        }

        public void PostAllMustHaveSkus(List<MustHaveSku> list)
        {
            try
            {
                foreach (var mustHaveSku in list)
                {
                    this._db.MustHaveSkus.Add(mustHaveSku);
                }
                log.Debug("saved mustHaveSkus in database successfully");
            }
            catch (Exception)
            {
                log.Debug("error saving mustHaveSkus in database!");
                throw;
            }
        }

        public List<MustHaveSkusBasic> GetAllMustHaveSkusBasic()
        {
            return  (from m in this._db.MustHaveSkusBasics
                       select m).ToList();
        }

        public void PostAllMustHaveSkusBasic(List<MustHaveSkusBasic> list)
        {
            try
            {

                foreach (var mustHaveSkusBasic in list)
                {
                    this._db.MustHaveSkusBasics.Add(mustHaveSkusBasic);
                }
                log.Debug("added basic skus successfully");
            }
            catch (Exception)
            {
                log.Debug("error adding basic skus");
                throw;
            }
        }

        public List<FixedDisplayBasic> GetAllFixedDisplayBasic()
        {
            return (from m in this._db.FixedDisplayBasics
                    select m).ToList();
            
        }

        public List<WaveDisplayBasic> GetAllWaveDisplayBasic()
        {
            return (from m in this._db.WaveDisplayBasics
                    select m).ToList();
            
        }

        public List<HotSpotBasic> GetAllHotSpotBasic()
        {
            return (from m in this._db.HotSpotBasics
                    select m).ToList();
        }

        public List<POPBasic> GetAllPopBasic()
        {
            return (from m in this._db.POPBasics
                    select m).ToList();
        }

        public List<AdditionalSkuBasic> GetAllAdditionalSkuBasic()
        {
            return (from m in this._db.AdditionalSkuBasics
                    select m).ToList();
        }
    }
}
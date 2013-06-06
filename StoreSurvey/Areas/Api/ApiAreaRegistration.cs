using System.Web.Mvc;

namespace StoreSurvey.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
               "ListShopsAll",
               "Api/Shops",
               new
               {
                   controller = "Shops",
                   action = "ShopsList",
                   page = UrlParameter.Optional,
                   count = UrlParameter.Optional
               }
           );
            context.MapRoute(
                "ListShopPaged",
                "Api/Shops/ShopsList/{pageNum}/{chunkSize}",
                new
                    {
                        controller = "Shops",
                        action = "ShopsList",
                        pageNum = UrlParameter.Optional,
                        chunkSize = UrlParameter.Optional        
                    }
                );

            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}


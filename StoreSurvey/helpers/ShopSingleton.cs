using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreSurvey.helpers
{
    class ShopSingleton
    {
        private static ShopSingleton instance;
        public StoreSurveyEntities _db = new StoreSurveyEntities();
        private ShopSingleton() { }

        public static ShopSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new ShopSingleton();

                return instance;
            }
        }
    }

}

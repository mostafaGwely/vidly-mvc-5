using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());

            //filters.Add(new OutputCacheAttribute {Duration = 50,
            //    Location = OutputCacheLocation.Client});


        }
    }
}

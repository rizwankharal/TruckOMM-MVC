using System.Web;
using System.Web.Mvc;
using TRANSPORTATIONMANAGEMENTSYSTEM.Filters;

namespace TRANSPORTATIONMANAGEMENTSYSTEM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticationFilter());
        }
    }
}

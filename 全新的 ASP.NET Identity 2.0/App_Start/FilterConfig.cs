using System.Web;
using System.Web.Mvc;

namespace 全新的_ASP.NET_Identity_2._0
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

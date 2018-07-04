using System.Web;
using System.Web.Mvc;

namespace 使用_Cookie_做身份驗證
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

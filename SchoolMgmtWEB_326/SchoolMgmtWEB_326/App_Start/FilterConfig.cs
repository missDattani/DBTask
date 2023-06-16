using System.Web;
using System.Web.Mvc;

namespace SchoolMgmtWEB_326
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

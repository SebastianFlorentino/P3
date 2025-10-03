using ProjectWeb_1.Filters;
using System.Web;
using System.Web.Mvc;

namespace ProjectWeb_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificaSession());
        }
    }
}

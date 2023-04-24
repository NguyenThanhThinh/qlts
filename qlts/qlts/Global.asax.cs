using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;

namespace qlts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start( )
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters ( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes ( RouteTable.Routes );
            BundleConfig.RegisterBundles ( BundleTable.Bundles );
            JsonConvert.DefaultSettings = ( ) => new JsonSerializerSettings
                                                 {
                                                     Formatting = Formatting.Indented,
                                                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                 };
            DependencyConfig.Register();
            MapperConfig.Register();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
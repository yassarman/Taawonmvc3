using System;
using System.Threading;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Abp.WebApi.Validation;
using Castle.Facilities.Logging;
using TaawonMVC.Web.Models.AntiForgery;

namespace TaawonMVC.Web
{
    public class MvcApplication : AbpWebApplication<TaawonMVCWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );
            
            base.Application_Start(sender, e);
            //rigister fillter 
            // AreaRegistration.RegisterAllAreas();
            // GlobalFilters.Filters.Add(new ValidateAntiForgeryTokenOnAllPosts());
         

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        #region Variables

        public Logger Log { get; set; }
        protected IConfigurationRoot Configuration { get; set; }

        #endregion Variables

        #region Public methods

        public BaseController() 
        {
            LogManager.Configuration = new XmlLoggingConfiguration(Environment.CurrentDirectory + "/NLog.config");
            this.Log = LogManager.GetCurrentClassLogger();
            
            this.Configuration = new ConfigurationBuilder().AddJsonFile(Environment.CurrentDirectory + "/appSettings.json").Build();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FileTarget target = (FileTarget)LogManager.Configuration.FindTargetByName("ownFile-web");
            DateTime dateTime = DateTime.Now;
            target.FileName = $"{this.Configuration["nlogDirectory"]}/nlog-{dateTime:yyyyMMdd}.log";
            LogManager.ReconfigExistingLoggers();
        }

        #endregion Public methods

    }
}

﻿using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebApiStarter.Template1.App_Start;
using Compusight.MoveDesk.UserManagementApi.Configuration;

[assembly: OwinStartup(typeof(WebApiStarter.Template1.Startup))]

namespace WebApiStarter.Template1
{
    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            CorsConfig.ConfigureCors(ConfigurationManager.AppSettings["cors"]);
            app.UseCors(CorsConfig.Options);

            var configuration = new HttpConfiguration();

            AutofacConfig.Configure(configuration);
            app.UseAutofacMiddleware(AutofacConfig.Container);

            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);
            ServiceConfig.Configure(configuration);
            SwaggerConfig.Configure(configuration);

            app.UseWebApi(configuration);
        }
    }
}
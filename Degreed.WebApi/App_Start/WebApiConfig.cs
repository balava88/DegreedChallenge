using Degreed.WebApi.Core;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace Degreed.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = (IUnityContainer)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUnityContainer));
            HighlighterMessageHandler highlighterMessageHandler = container.Resolve<HighlighterMessageHandler>();

            // Add HighLighter MessageHandler
            config.MessageHandlers.Add(highlighterMessageHandler);

            // Web API routes
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger")
            );

        }
    }
}

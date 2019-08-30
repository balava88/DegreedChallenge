using Business.Contracts.Contracts;
using Data;
using Data.Contracts.Contracts;
using Data.Repositories;
using Degreed.Business;
using Degreed.Business.Factories;
using Degreed.Shared.Contracts;
using Degreed.Shared.Highlighters;
using Degreed.Shared.Utilities;
using System.Configuration;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace Degreed.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            var appSettings = ConfigurationManager.AppSettings;

            container.RegisterType<IBusinessFactory, BusinessFactory>();

            //Emphasize Highlighter
            //container.RegisterType<IHighlighter, EmphasizeHighlighter>();
            //Bold Highlighter
            //container.RegisterType<IHighlighter, BoldHighlighter>();
            //Mark Highlighter
            //container.RegisterType<IHighlighter, MarkHighlighter>();
            //Custom Highlighter
            container.RegisterType<IHighlighter, CustomHighlighter>();

            container.RegisterType<IJokeBusiness, JokeBusiness>();

            container.RegisterType<IRepositoryFactory, RepositoryFactory>();

            container.RegisterType<IJokesHelper, JokesHelper>();

            container.RegisterType<IJokeRepository, JokeRepository>(new InjectionConstructor(appSettings));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
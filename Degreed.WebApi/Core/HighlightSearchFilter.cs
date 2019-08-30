using Degreed.Domain.Models;
using Degreed.Shared.Contracts;
using Degreed.Shared.Utilities;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Unity;

namespace Degreed.WebApi.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class HighlightSearch : ActionFilterAttribute
    {
        private readonly IHighlighter _highlighter;
        private readonly IJokesHelper _helper;

        /// <summary>
        /// ActionFilter that implements the Highlight functionality
        /// </summary>
        public HighlightSearch()
        {
            var container = (IUnityContainer)GlobalConfiguration.
                Configuration.DependencyResolver.GetService(typeof(IUnityContainer));
            
            _highlighter = container.Resolve<IHighlighter>(); ;
            _helper = container.Resolve<IJokesHelper>(); ;
        }

        /// <summary>
        /// Highlights searched term for the result jokes
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {          
            if (context.Response?.Content is ObjectContent objectContent &&
                objectContent.ObjectType == typeof(JokesModels))
            {
                var jokeModels = (JokesModels)objectContent.Value;

                if (jokeModels.Results  != null)
                {
                    foreach (var item in jokeModels.Results)
                    {
                        item.Joke = _helper.HighLight(item.Joke, jokeModels.SearchTerm, _highlighter);
                    }
                }                
            }

        }
    }
}
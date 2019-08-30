using Degreed.Domain.Models;
using Degreed.Shared.Contracts;
using Degreed.Shared.Utilities;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Degreed.WebApi.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class HighlighterMessageHandler : DelegatingHandler
    {

        private readonly IHighlighter _highlighter;
        private readonly IJokesHelper _helper;


        /// <summary>
        /// HttpMessageHandler that implements the Highlight functionality
        /// </summary>
        /// <param name="highlighter"></param>
        /// <param name="helper"></param>
        public HighlighterMessageHandler(IHighlighter highlighter, JokesHelper helper)
        {
            _highlighter = highlighter;
            _helper = helper;
        }

        /// <summary>
        /// Intercepts and changes Response Messages to implement the Highlight functionality
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {            
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                        
            //Modify Response Message using Highlighter
            if (response?.Content is ObjectContent objectContent && objectContent.ObjectType == typeof(JokesModels))
            {
                var jokeModels = (JokesModels)objectContent.Value;

                foreach (var item in jokeModels.Results)
                {
                    item.Joke = _helper.HighLight(item.Joke, jokeModels.SearchTerm, _highlighter);
                }
            }

            return response;
        }
    }
}
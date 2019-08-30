using NLog;
using System;
using System.Linq;
using System.Security;
using System.Web.Http;

namespace Degreed.WebApi.Core
{
    /// <summary>
    /// Provides shared functionality for API controllers 
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Provides API standard responses 
        /// </summary>
        /// <param name="codeToExecute"></param>
        /// <returns></returns>
        protected IHttpActionResult GetHttpResponse(Func<IHttpActionResult> codeToExecute)
        {
            IHttpActionResult response;
            try
            {
                response = ModelState.IsValid ? codeToExecute.Invoke() : BadRequest(ModelState.Values.SelectMany(r => r.Errors.Select(x => x.ErrorMessage)).FirstOrDefault());
            }
            catch (SecurityException)
            {
                response = Unauthorized();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                response = InternalServerError(new Exception("Oops. something went wrong. please try again later."));
            }
            return response;
        }
    }
}
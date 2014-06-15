using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses;

namespace Durango.Web
{
    public class ErrorStatusCodeHandler : IStatusCodeHandler
    {
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound || 
                   statusCode == HttpStatusCode.InternalServerError;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var error = new Error { StatusCode = (int) statusCode };
            error.ErrorMessage = 
                statusCode == HttpStatusCode.NotFound ? "Not Found" : "Internal Server Error.";

            var jsonResponse = new JsonResponse(error, new JsonNetSerializer());
            context.Response = jsonResponse.WithStatusCode(statusCode);
        }
    }
}
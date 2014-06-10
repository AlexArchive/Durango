using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses;
using System.Linq;

namespace Service
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

            // unfavourable approach to content-negotation until I can figure out how to use the
            // IResponseNegotiator introduced in Nancy 0.23

            var clientWantsXml = context.Request.Headers.Accept.Any(
                header => header.Item1 == "text/xml" || header.Item1 == "application/xml");

            if (clientWantsXml)
            {
                var xmlResponse = new XmlResponse<Error>(error, "text/xml", new DefaultXmlSerializer());
                context.Response = xmlResponse.WithStatusCode(statusCode);
                return;
            }

            var jsonResponse = new JsonResponse(error, new JsonNetSerializer());
            context.Response = jsonResponse.WithStatusCode(statusCode);
        }
    }
}
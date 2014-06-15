using Nancy;
using Nancy.Responses.Negotiation;

namespace Durango.Web
{
    public static class ErrorExtensions
    {
        public static Negotiator ErrorMessage(this NancyModule module, HttpStatusCode statusCode, string message)
        {
            return module.Negotiate
                .WithModel(new Error { StatusCode = (int) statusCode, ErrorMessage = message })
                .WithStatusCode(statusCode);
        }
    }
}
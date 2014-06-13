using Nancy;
using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;

namespace Service
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                // remove unwanted processors from the content-negotation pipeline.
                return NancyInternalConfiguration.WithOverrides(
                    x =>
                    {
                        x.ResponseProcessors.Remove(typeof (ViewProcessor));
                        x.ResponseProcessors.Remove(typeof (XmlProcessor));
                    });
            }
        }
    }
}
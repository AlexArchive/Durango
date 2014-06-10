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
                // remove view processor from the content-negotation pipeline.
                return NancyInternalConfiguration.WithOverrides(
                    x => x.ResponseProcessors.Remove(typeof(ViewProcessor)));
            }
        }
    }
}
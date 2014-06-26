using Nancy;

namespace Durango.Web.Modules
{
    public abstract class ModuleBase : NancyModule
    {
        protected static XboxClient XboxClient { get; set; }

        static ModuleBase()
        {
            XboxClient = new XboxClient(/*"twerkteam@yopmail.com", "teamtwerk1"*/);
        }
    }
}
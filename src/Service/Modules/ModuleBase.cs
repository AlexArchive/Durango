using Framework;
using Nancy;

namespace Service.Modules
{
    public abstract class ModuleBase : NancyModule
    {
        protected static XboxClient _xboxClient;

        static ModuleBase()
        {
            _xboxClient = new XboxClient("twerkteam@yopmail.com", "teamtwerk1");
        }
    }
}
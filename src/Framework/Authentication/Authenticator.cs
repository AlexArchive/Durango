using System.Text;
using Framework.Common;
using Framework.Infrastructure;

namespace Framework.Authentication
{
    public class Authenticator
    {
        private readonly string _username;
        private readonly string _password;

        public Authenticator(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void Apply(WebAgent webAgent)
        {
            bool authenticated = Authenticate(webAgent);
            
            // TODO:
            //   Handle error.
        }

        private bool Authenticate(WebAgent webAgent)
        {
            var content = webAgent.GetString(
                "https://live.xbox.com/Account/Signin?returnUrl=http%3a%2f%2fwww.xbox.com%2fen-US%2f");

            var postUrl = content.ParseBetween("urlPost:'", "'");
            var ppftVal = content.ParseBetween("name=\"PPFT\" id=\"i0327\" value=\"", "\"");
            var ppsxVal = content.ParseBetween("j:'", "'");

            var postContent = new StringBuilder();
            postContent.Append("login=" + _username);
            postContent.Append("&passwd=" + _password);
            postContent.Append("&SI=Sign in");
            postContent.Append("&type=11");
            postContent.Append("&PPFT=" + ppftVal);
            postContent.Append("&PPSX=" + ppsxVal);
            postContent.Append("&idsbho=1");
            postContent.Append("&sso=0");
            postContent.Append("&NewUser=1");
            postContent.Append("&LoginOptions=3");
            postContent.Append("&i1=0");
            postContent.Append("&i2=1");
            postContent.Append("&i3=34903");
            postContent.Append("&i4=0");
            postContent.Append("&i7=0");
            postContent.Append("&i12=1");
            postContent.Append("&i13=0");
            postContent.Append("&i14=79");
            postContent.Append("&i15=1605");
            postContent.Append("&i18=__Login_Strings|1,__Login_Core|1,");

            var response = webAgent.Post(postUrl, postContent.ToString());
            content = response.GetResponseStream().ReadAsString();

            postUrl = content.ParseBetween("id=\"fmHF\" action=\"", "\"");
            var napVal = content.ParseBetween("id=\"NAP\" value=\"", "\"");
            var anonVal = content.ParseBetween("id=\"ANON\" value=\"", "\"");
            var tVal = content.ParseBetween("id=\"t\" value=\"", "\"");

            postContent.Clear();
            postContent.Append("NAP=" + napVal);
            postContent.Append("&ANON=" + anonVal);
            postContent.Append("&t=" + tVal);

            response = webAgent.Post(postUrl, postContent.ToString());
            content = response.GetResponseStream().ReadAsString();

            return content.Contains("https://live.xbox.com/Account/Signout");
        }
    }
}
using Framework.Common;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Framework.Infrastructure
{
    public sealed class WebAgent
    {
        private readonly CookieContainer _cookieContainer = new CookieContainer();

        public WebAgent()
        {
            ServicePointManager.DefaultConnectionLimit = 10;
        }

        public HttpWebResponse Get(string requestUri)
        {
            return Send(HttpMethod.Get, requestUri);
        }

        public string GetString(string requestUri)
        {
            var response = Send(HttpMethod.Get, requestUri);
            return response.GetResponseStream().ReadAsString();
        }

        public HttpWebResponse Post(string requestUri, string formContent,
            WebHeaderCollection headers = null)
        {
            return Send(HttpMethod.Post, requestUri, formContent, headers);
        }

        private HttpWebResponse Send(HttpMethod method, string requestUri, string formContent = null,
            WebHeaderCollection headers = null)
        {
            var request = CreateAndPrepareWebRequest(method, requestUri, formContent, headers);

            var response = (HttpWebResponse)request.GetResponse();
            ExtractResponseCookies(response);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // handle redirect
                requestUri = response.Headers["Location"];
                response = Get(requestUri);
            }

            return response;
        }

        private HttpWebRequest CreateAndPrepareWebRequest(HttpMethod method, string requestUri,
            string formContent = null, WebHeaderCollection headers = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = method.ToString();

            SetDefaultOptions(request);
            SetRequestHeaders(request, headers);
            SetContent(request, formContent);

            return request;
        }

        private void SetRequestHeaders(WebRequest request, WebHeaderCollection headers)
        {
            if (headers == null) return;

            foreach (var header in headers.AllKeys)
                request.Headers.Add(header, headers[header]);
        }

        [DebuggerStepThrough]
        private void SetDefaultOptions(HttpWebRequest request)
        {
            request.Proxy = null;
            request.KeepAlive = true;
            request.AllowAutoRedirect = false;
            request.Timeout = 10000;
            request.CookieContainer = _cookieContainer;
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
        }

        private void SetContent(WebRequest request, string formContent)
        {
            if (formContent == null) return;

            request.ContentType = "application/x-www-form-urlencoded";
            using (var writer = new StreamWriter(request.GetRequestStream()))
                writer.Write(formContent);
        }

        [DebuggerStepThrough]
        private void ExtractResponseCookies(WebResponse response)
        {
            var cookieHeader = response.Headers["Set-Cookie"];

            if (cookieHeader == null) return;

            var cookies = Regex.Matches(cookieHeader, "(?<name>.+?)=(?<val>.*?);.*?($|,(?! ))");

            foreach (Match cookie in cookies)
            {
                _cookieContainer.Add(
                    new Cookie(cookie.Groups["name"].Value, cookie.Groups["val"].Value, "/",
                        response.ResponseUri.Host));
            }
        }
    }
}
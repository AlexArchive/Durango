using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Durango.Common
{
    internal static class StreamExtensions
    {
        internal static string ReadAsString(this Stream stream)
        {
            // TODO:
            //  Consideration for encoding.

            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }
    }

    internal static class StringExtensions
    {
        internal static string ParseBetween(this string input, string leftWord, string rightWord)
        {
            leftWord = Regex.Escape(leftWord);
            rightWord = Regex.Escape(rightWord);

            var pattern = new Regex(leftWord + "(?<word>.*?)" + rightWord, RegexOptions.Singleline);

            return pattern.Match(input).Groups["word"].Value;
        }
    }

    public static class WebRequestExtensions
    {
        public static WebResponse GetResponseWithoutException(this WebRequest request)
        {
            try
            {
                return request.GetResponse();
            }
            catch (WebException e)
            {
                return e.Response;
            }
        }
    }

#if DEBUG
    internal static class ObjectExtensions
    {
        internal static string ToStringAutomatic<T>(this T obj)
        {
            const string Seperator = "\r\n";
            const BindingFlags BindingFlags = BindingFlags.Instance | BindingFlags.Public;

            var propertyValues =
                from property in obj.GetType().GetProperties(BindingFlags)
                where property.CanRead
                select string.Format("{0} : {1}", property.Name, property.GetValue(obj, null));

            return string.Join(Seperator, propertyValues);
        }
    }
#endif  
}
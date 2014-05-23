using Framework.Infrastructure;
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Framework.Common
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

    internal static class WebAgentExtensions
    {
        internal static HtmlDocument DownloadDocumentNode(this WebAgent webAgent, string requestUri)
        {
            var pageData = webAgent.GetString(requestUri);

            var document = new HtmlDocument();
            document.LoadHtml(pageData);

            return document;
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
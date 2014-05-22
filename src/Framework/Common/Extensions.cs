using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Framework.Common
{
    public static class StreamExtensions
    {
        public static string ReadAsString(this Stream stream)
        {
            // TODO:
            //  Consideration for encoding.

            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }
    }

    public static class StringExtensions
    {
        public static string ParseBetween(this string input, string leftWord, string rightWord)
        {
            var pattern = new Regex(leftWord + "(?<word>.*?)" + rightWord);
            return pattern.Match(input).Groups["word"].Value;
        }
    }

    public static class ObjectExtensions
    {
        public static string ToStringAutomatic<T>(this T obj)
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
}
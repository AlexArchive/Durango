using System.IO;
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
}
using System.Text.RegularExpressions;

namespace scboilerplate.Foundation.SitecoreExtensions.Extensions
{
    public static class StringExtensions
    {
        public static string Humanize(this string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }

        public static string ToCssUrlValue(this string url)
        {
            return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
        }

        public static string ReplaceSpaeToDash(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return input.Replace(' ', '-');
        }
    }
}
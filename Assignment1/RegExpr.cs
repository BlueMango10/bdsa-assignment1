using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var match = Regex.Match(line, @"[a-zA-Z0-9]+");
                while (match.Value != "")
                {
                    yield return match.Value;
                    match = match.NextMatch();
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var match = Regex.Match(resolutions, @"(?<width>\d+)x(?<height>\d+)");
            while (match.Value != "")
            {
                var width = match.Groups["width"].Value;
                var height = match.Groups["height"].Value;
                yield return (int.Parse(width), int.Parse(height));
                match = match.NextMatch();
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using Xunit;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        #region SplitLine
        [Theory]
        [InlineData(new[]{"Foo Bar"}, new[]{"Foo", "Bar"})]
        [InlineData(new[]{"Foo!Bar"}, new[]{"Foo", "Bar"})]
        [InlineData(new[]{"foo bar"}, new[]{"foo", "bar"})]
        [InlineData(new[]{"foobar foobar raboof"}, new[]{"foobar", "foobar", "raboof"})]
        [InlineData(new[]{"fooBar"}, new[]{"fooBar"})]
        public void SplitLine_splits_one_line(IEnumerable<string> line, IEnumerable<string> expected)
        {
            // Act
            var actual = RegExpr.SplitLine(line);

            // Assert
            Assert.Equal(expected, actual);            
        }
        
        [Fact]
        public void SplitLine_splits_multiple_lines()
        {
            // Arrange
            var lines = new[]{
                "Foo Bar",
                "Foo!Bar",
                "foo bar",
                "fooBar",
                "foobar foobar raboof"
            };

            var expected = new[]{
                "Foo", "Bar",
                "Foo", "Bar",
                "foo", "bar",
                "fooBar",
                "foobar", "foobar", "raboof"
            };

            // Act
            var actual = RegExpr.SplitLine(lines);

            // Assert
            Assert.Equal(expected, actual); 
        }
        #endregion

        #region Resolutions
        [Fact]
        public void Resolutions_1920x1080()
        {
            // Arrange
            var resolutions = "1920x1080";

            // Act
            var actual = RegExpr.Resolution(resolutions);

            // Assert
            var expected = new[]{(1920, 1080)};
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Resolutions_1024x768_800x600_640x480()
        {
            // Arrange
            var resolutions = "1024x768, 800x600, 640x480";

            // Act
            var actual = RegExpr.Resolution(resolutions);

            // Assert
            var expected = new[]{(1024, 768), (800, 600), (640, 480)};
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Resolutions_320x200_320x240_800x600()
        {
            // Arrange
            var resolutions = "320x200, 320x240, 800x600";

            // Act
            var actual = RegExpr.Resolution(resolutions);

            // Assert
            var expected = new[]{(320, 200), (320, 240), (800, 600)};
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Resolutions_1280x960()
        {
            // Arrange
            var resolutions = "1280x960";

            // Act
            var actual = RegExpr.Resolution(resolutions);

            // Assert
            var expected = new[]{(1280, 960)};
            Assert.Equal(expected, actual);
        }
        #endregion

        #region InnerText
        [Theory]
        [InlineData("a", new[]{
            "theoretical computer science",
            "formal language",
            "characters",
            "pattern",
            "string searching algorithms",
            "strings"
        })]
        [InlineData("p", new[]{
            "A regular expression, regex or regexp (sometimes called a rational expression) is, in theoretical computer science and formal language theory, a sequence of characters that define a search pattern. Usually this pattern is then used by string searching algorithms for \"find\" or \"find and replace\" operations on strings."
        })]
        [InlineData("b", new[]{
            "regular expression",
            "regex",
            "regexp",
            "rational expression"
        })]
        [InlineData("div", new[]{
            "A regular expression, regex or regexp (sometimes called a rational expression) is, in theoretical computer science and formal language theory, a sequence of characters that define a search pattern. Usually this pattern is then used by string searching algorithms for \"find\" or \"find and replace\" operations on strings."
        })]
        public void InnerText_by_tag(string tag, IEnumerable<string> expected)
        {
            // Arrange
            var html =
            "<div>" +
            "<p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>" +
            "</div>";
            // Act
            var actual = RegExpr.InnerText(html, tag);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}

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
        #endregion
    }
}

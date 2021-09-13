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
                "Foo", "bar",
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
        public void Resolutions_one_entry_per_element(string resolutions, IEnumerable<(int width, int height)> expected)
        {
            // Act
            var actual = RegExpr.Resolution(resolutions);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region InnerText
        #endregion
    }
}

using System.Collections.Generic;
using Xunit;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void Flatten_returns_012345()
        {
            // Arrange
            var stream = new[] {
                new[]{0,1,2},
                new[]{3,4},
                new[]{5,6,7,8}
            };

            // Act
            var result = Iterators.Flatten(stream);

            // Assert
            IEnumerable<int> expected = new[]{0,1,2,3,4,5,6,7,8};
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Filter_returns_246_from_1234567()
        {
            // Arrange
            var input = new[]{1,2,3,4,5,6,7};

            // Act
            var result = Iterators.Filter(input, p => p % 2 == 0);

            // Assert
            IEnumerable<int> expected = new[]{0,1,2,3,4,5,6,7,8};
            Assert.Equal(result, expected);
        }
    }
}

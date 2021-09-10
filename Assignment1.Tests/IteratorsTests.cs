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
            var expected = new[]{0,1,2,3,4,5,6,7,8}.GetEnumerator();
            // TODO: Find the correct way to assert this.
            foreach (var item in result)
            {
                expected.MoveNext();
                Assert.Equal(result, expected.Current);
            }
        }

        [Fact]
        public void Filter_returns_246_from_1234567()
        {
            // Arrange
            var input = new[]{1,2,3,4,5,6,7};

            // Act
            var result = Iterators.Filter(input, p => p % 2 == 0);

            // Assert
            var expected = new[]{2,3,6}.GetEnumerator();
            foreach (var item in result)
            {
                expected.MoveNext();
                Assert.Equal(result, expected.Current);
            }
        }
    }
}


namespace Task01.Tests
{
    public class FirstPartTests
    {
        [Theory]
        [InlineData(0, -10)]
        public void IsWrongLengthVectorCreatingFailed(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstPart(a));
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstPart(b));
        }

        [Fact]
        public void IsVectorContainsNegatives()
        {
            var firstPart = new FirstPart(100);
            Assert.Contains(firstPart.Vector, p => p < 0);
        }

        [Fact]
        public void IsSumValid()
        {
            var firstPart = new FirstPart(100);
            Assert.Equal(firstPart.GetSumOfNegativeElements(), firstPart.Vector.Where(i => i < 0).Sum());
        }

        [Fact]
        public void IsMultiplicationValid()
        {
            var firstPart = new FirstPart(100);
            var arr = firstPart.Vector.ToArray();

            var minIndex = Array.IndexOf(arr, arr.Min());
            var maxIndex = Array.IndexOf(arr, arr.Max());

            if (minIndex > maxIndex)
            {
                var tmp = minIndex;
                minIndex = maxIndex;
                maxIndex = tmp;
            }

            var fpMul = firstPart.GetMultiplicationBetweenMinMax();

            var mul = arr.Skip(minIndex + 1).Take(maxIndex - minIndex - 1).ToList();
            if (mul.Count == 0)
            {
                Assert.Equal(1, fpMul);
            }
            else
            {
                Assert.Equal(mul.Aggregate((a, n) => a * n), fpMul);
            }
        }

        [Fact]
        public void IsSortedByAscending()
        {
            var fp = new FirstPart(100);

            var sorted = fp.Vector.OrderBy(i => i).ToArray();
            fp.SortByAscending();
            Assert.Equal(sorted, fp.Vector);
        }


    }
}
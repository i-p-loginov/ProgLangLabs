using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Tests
{
    public class SecondPartTests
    {
        [Fact]
        public void CountRowsWithoutZeros()
        {
            var sp = new SecondPart(10, 10);
            var actualCount = sp.GetRowsWithoutZerosCount();

            var expectedCount = sp.Matrix.OfType<int>().Chunk(sp.Matrix.GetLength(1))
                                                       .Where(i => i.All(n => n != 0))
                                                       .Count();

            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void FindMaxRepeatingValue()
        {
            var sp = new SecondPart(3, 3);
            var actualMax = sp.GetMaxRepeatingNumber();

            int? expectedMax = sp.Matrix.OfType<int>()
                                .GroupBy(i => i)
                                .OrderByDescending(g => g.Count())
                                .Select(g => g.Key)
                                .First();

            if (expectedMax == 1)
                expectedMax = null;

            Assert.Equal(expectedMax, actualMax);
        }
    }
}

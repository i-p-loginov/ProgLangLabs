using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class FirstPart
    {
        private readonly int[] array;

        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }

        public int GetSumOfNegativeElements()
        {
            int sum = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    sum += array[i];
                }
            }

            return sum;
        }

        public void SortByAscending()
        {
            Array.Sort(array);
        }

        public int GetMultiplicationBetweenMinMax()
        {
            int min = array.Min();
            int max = array.Max();

            var minIndex = Array.IndexOf(array, min);
            var maxIndex = Array.IndexOf(array, max);

            if (minIndex > maxIndex)
            {
                var tmp = minIndex;
                minIndex = maxIndex;
                maxIndex = tmp;
            }

            int mul = 1;

            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                mul *= array[i];
            }

            return mul;
        }
    }
}

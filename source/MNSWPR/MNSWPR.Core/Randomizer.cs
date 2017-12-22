using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSWPR.Core
{
    public class Randomizer
    {
        public int[] GetRandomNumbers(int count, int maxValue)
        {
            var result = new int[count];
            var range = Enumerable.Range(0, maxValue).ToList();
            var random = new Random(DateTime.Now.GetHashCode());
            for (var i = 0; i < count; i++)
            {
                var nextIndex = random.Next(maxValue - i);
                result[i] = range[nextIndex];
                range.RemoveAt(nextIndex);
            }
            return result;
        }

        public int GetRandomNumber(int maxValue)
        {
            var random = new Random(DateTime.Now.GetHashCode());
            return random.Next(maxValue);
        }
    }
}

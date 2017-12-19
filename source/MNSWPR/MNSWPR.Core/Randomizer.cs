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
            var numbers = new int[count];
            var r = new Random(DateTime.Now.GetHashCode());
            for(var i = 0; i < count; i++)
            {
                numbers[i] = r.Next(maxValue);
            }
            return numbers;
        }
    }
}

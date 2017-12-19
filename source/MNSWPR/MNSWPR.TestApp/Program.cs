using MNSWPR.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSWPR.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    var r = new Randomizer();
            //    var a = r.GetRandomNumbers(5, 25).ToList();
            //    a.Sort();
            //    foreach (var item in a)
            //        Console.WriteLine(item);
            //    Console.WriteLine("========================");
            //    //check to similarity
            //    for(var i = 0; i < a.Count() - 1; i++)
            //    {
            //        if (a[i] == a[i + 1])
            //        {
            //            Console.WriteLine("error");
            //            a[i + 1] = (a[i + 1] + 1) % 25;
            //            foreach (var item in a)
            //                Console.WriteLine(item);
            //        }
            //    }
            //    Console.ReadKey();
            //    Console.Clear();
            //}

            while (true)
            {
                var a = new int[5];
                var range = Enumerable.Range(0, 25).ToList();
                var random = new Random(DateTime.Now.GetHashCode());
                for (var i = 0; i < 5; i++)
                {
                    var nextIndex = random.Next(25 - i);
                    a[i] = range[nextIndex];
                    range.RemoveAt(nextIndex);
                }
                foreach (var item in a)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

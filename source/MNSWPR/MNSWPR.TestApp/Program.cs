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
            var rows = 5;
            var field = new Field(rows, rows, 5);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    if (field.Mined(i, j))
                        Console.Write(1);
                    else
                        Console.Write(0);
                }
                Console.WriteLine();
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    if (field.Mined(i, j))
                    {
                        field.ReplaceBombFromCell(i, j);
                        for (var k = 0; k < rows; k++)
                        {
                            for (var l = 0; l < rows; l++)
                            {
                                if (field.Mined(k, l))
                                    Console.Write(1);
                                else
                                    Console.Write(0);
                            }
                            Console.WriteLine();
                        }
                        return;
                    }

                }
                Console.WriteLine();
            }



        }
    }
}

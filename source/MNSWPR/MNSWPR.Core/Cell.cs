using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSWPR.Core
{
    public struct Cell
    {
        public Cell(int i, int j, int rowsCount)
        {
            I = i;
            J = j;
            Index = i * rowsCount + j;
        }

        public int I { get; private set; }
        public int J { get; private set; }
        public int Index { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSWPR.Core
{
    public class Coordinates
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Coordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}

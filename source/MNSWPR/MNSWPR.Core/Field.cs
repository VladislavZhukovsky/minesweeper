using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSWPR.Core
{
    public class Field
    {
        private int rows;
        private int cols;

        private Cell[] minedCells;

        public Field()
        {
            this.rows = 5;
            this.cols = 5;

            minedCells = new Cell[5]
            {
                new Cell(0, 4, 5),
                new Cell(1, 2, 5),
                new Cell(2, 4, 5),
                new Cell(3, 3, 5),
                new Cell(4, 1, 5)
            };
        }
    }
}

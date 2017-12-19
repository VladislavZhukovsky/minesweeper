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

        //keep ALL cells (not only mined) to access cell directly ( O(1) operation)
        //true if mined
        private bool[] cells;

        public Field(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            cells = new bool[rows * cols];
            SetMines();
        }

        private void SetMines()
        {
            var r = new Randomizer();
            var mineIndexes = r.GetRandomNumbers(5, rows * cols);
            foreach(var index in mineIndexes)
            {
                cells[index] = true;
            }
        }
    }
}

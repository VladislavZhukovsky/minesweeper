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

        public bool Mined(int row, int col)
        {
            return cells[row * rows + col];
        }

        public int CountMinesAround(int row, int col)
        {
            var result = 0;
            //N- North, S - south, E - East, W - West
            //int NWrow;
            //int NWcol;
            //int Nrow;
            //int Ncol;
            //int NErow;
            //int NEcol;
            //int Erow;
            //int Ecol;
            //int SErow;
            //int SEcol;
            //int Srow;
            //int Scol;
            //int SWrow;
            //int SWcol;
            //int Wrow;
            //int Wcol;

            //NWrow = Nrow = NErow = row - 1;
            //Wrow = Erow = row;
            //SWrow = Srow = SErow = row + 1;
            //NWcol = Wcol = SWcol = col - 1;
            //Ncol = Scol = col;
            //NEcol = Ecol = SEcol = col + 1;

            var upRow     = row - 1;
            var centerRow = row;
            var downRow   = row + 1;
            var leftCol   = col - 1;
            var centerCol = col;
            var rightCol  = col + 1;

            if (IsValidCellCoordinates(upRow,     leftCol))   { if (Mined(upRow,     leftCol))   { result++; } }
            if (IsValidCellCoordinates(upRow,     centerCol)) { if (Mined(upRow,     centerCol)) { result++; } }
            if (IsValidCellCoordinates(upRow,     rightCol))  { if (Mined(upRow,     rightCol))  { result++; } }
            if (IsValidCellCoordinates(centerRow, rightCol))  { if (Mined(centerRow, rightCol))  { result++; } }
            if (IsValidCellCoordinates(downRow,   rightCol))  { if (Mined(downRow,   rightCol))  { result++; } }
            if (IsValidCellCoordinates(downRow,   centerCol)) { if (Mined(downRow,   centerCol)) { result++; } }
            if (IsValidCellCoordinates(downRow,   leftCol))   { if (Mined(downRow,   leftCol))   { result++; } }
            if (IsValidCellCoordinates(centerRow, leftCol))   { if (Mined(centerRow, leftCol))   { result++; } }

            return result;
        }

        /// <summary>
        /// Checks if the value is in specified range (including min and max value)
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="min">Beginning of range</param>
        /// <param name="max">End of range</param>
        /// <returns></returns>
        private bool IsValidCellCoordinates(int row, int col)
        {
            return !(row < 0 || row >= rows || col < 0 || col >= cols);
        }
    }
}

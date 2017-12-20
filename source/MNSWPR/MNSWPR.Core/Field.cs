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
            int NWrow; int NWcol;
            int Nrow;  int Ncol;
            int NErow; int NEcol;
            int Erow;  int Ecol;
            int SErow; int SEcol;
            int Srow;  int Scol;
            int SWrow; int SWcol;
            int Wrow;  int Wcol;


            NWrow = Nrow = NErow = row - 1;
            Wrow = Erow = row;
            SWrow = Srow = SErow = row + 1;
            NWcol = Wcol = SWcol = col - 1;
            Ncol = Scol = col;
            NEcol = Ecol = SEcol = col + 1;

            if (NWrow >= 0 && NWcol >= 0) { if (Mined(NWrow, NWcol)) { result++; } }
            if (Nrow  >= 0 && Ncol  >= 0) { if (Mined(Nrow,  Ncol))  { result++; } }
            if (NErow >= 0 && NEcol >= 0) { if (Mined(NErow, NEcol)) { result++; } }
            if (Erow  >= 0 && Ecol  >= 0) { if (Mined(Erow,  Ecol))  { result++; } }
            if (SErow >= 0 && SEcol >= 0) { if (Mined(SErow, SEcol)) { result++; } }
            if (Srow  >= 0 && Scol  >= 0) { if (Mined(Srow,  Scol))  { result++; } }
            if (SWrow >= 0 && SWcol >= 0) { if (Mined(SWrow, SWcol)) { result++; } }
            if (Wrow  >= 0 && Wcol  >= 0) { if (Mined(Wrow,  Wcol))  { result++; } }

            return result;
        }
    }
}

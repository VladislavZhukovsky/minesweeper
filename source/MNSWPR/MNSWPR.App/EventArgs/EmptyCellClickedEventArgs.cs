using MNSWPR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSWPR.App.EventArgs
{
    public class EmptyCellClickedEventArgs
    {
        private bool mined;
        private IEnumerable<Coordinates> cellsAround;

        public EmptyCellClickedEventArgs()
        {

        }

        public EmptyCellClickedEventArgs(bool mined, IEnumerable<Coordinates> cellsAround)
        {
            this.cellsAround = cellsAround;
        }

        public bool Mined
        {
            get
            {
                return mined;
            }
        }

        public IEnumerable<Coordinates> CellsAround
        {
            get
            {
                return cellsAround;
            }
        }
    }
}

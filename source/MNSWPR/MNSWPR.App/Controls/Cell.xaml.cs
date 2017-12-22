using MNSWPR.App.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MNSWPR.App.Controls
{
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        private MainWindow parent;

        private int row;
        private int col;
        private CellState state;
        //private Core.Field coreField;

        public event ClickHandler EmptyCellClicked;
        public event ClickHandler MinedCellClicked;
        public delegate void ClickHandler(Cell clickedCell, EmptyCellClickedEventArgs args);


        public Cell(int row, int col, MainWindow parent)
        {
            this.parent = parent;
            if (row < 0 || col < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid cell coordinates");
            }
            this.row = row;
            this.col = col;
            this.state = CellState.NotClicked;
            //this.coreField = coreField;
            InitializeComponent();
            MouseLeftButtonUp += Cell_MouseLeftButtonUp;
            MouseRightButtonUp += Cell_MouseRightButtonUp;
        }

        public int Row
        {
            get
            {
                return row;
            }
        }

        public int Col
        {
            get
            {
                return col;
            }
        }

        public CellState State
        {
            get
            {
                return state;
            }
        }

        private void Cell_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!parent.FirstStepDone)
            {
                if (parent.Field.Mined(row, col))
                {
                    parent.Field.ReplaceBombFromCell(row, col);
                }
                parent.FirstStepDone = true;
            }
            Click();
        }

        private void Cell_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (state == CellState.NotClicked)
            {
                cellField.Background = Brushes.Yellow;
                state = CellState.FlagSet;
                return;
            }
            if (state == CellState.FlagSet)
            {
                cellField.Background = Brushes.LightGray;
                state = CellState.NotClicked;
                return;
            }
        }

        public void Click()
        {
            if (state == CellState.NotClicked)
            {
                state = CellState.Processing;
                var mined = parent.Field.Mined(row, col);
                if (mined)
                {
                    cellField.Background = Brushes.Red;
                }
                else
                {
                    cellField.Background = Brushes.Green;
                    if (EmptyCellClicked != null)
                    {
                        EmptyCellClicked(this, new EmptyCellClickedEventArgs());
                    }
                }
                state = CellState.Clicked;
            }
        }
    }
}

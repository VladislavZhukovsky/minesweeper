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
        private int row;
        private int col;
        private Core.Field coreField;

        private bool clicked;

        public Cell(int row, int col, Core.Field coreField)
        {
            if (row < 0 || col < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid cell coordinates");
            }
            this.row = row;
            this.col = col;
            this.coreField = coreField;

            InitializeComponent();
            MouseLeftButtonUp += Cell_MouseLeftButtonUp;
            MouseRightButtonUp += Cell_MouseRightButtonUp;
        }

        private void Cell_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!clicked)
            {
                var mined = coreField.Mined(row, col);
                if (mined)
                {
                    cellField.Background = Brushes.Red;
                }
                else
                {
                    cellField.Background = Brushes.Green;
                    text.Text = coreField.CountMinesAround(row, col).ToString();
                    text.Visibility = Visibility.Visible;
                }
                clicked = true;
            }
        }

        private void Cell_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            cellField.Background = Brushes.Yellow;
        }
    }
}

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
        private bool mined;
        private bool clicked;
        public Cell()
        {
            InitializeComponent();
            MouseUp += Cell_MouseUp;
        }

        public bool Mined
        {
            get
            {
                return mined;
            }
            set
            {
                mined = value;
                text.Text = mined ? "1" : "0";
            }
        }

        private void Cell_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!clicked)
            {
                cellField.Background = mined ? Brushes.Red : Brushes.Green;
                text.Visibility = Visibility.Visible;
                clicked = true;
            }
        }
    }
}

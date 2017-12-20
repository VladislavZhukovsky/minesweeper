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

namespace MNSWPR.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Controls.Cell> cells = new List<Controls.Cell>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeField();
        }

        private void InitializeField()
        {
            var rows = 5;
            var cols = 5;

            var coreField = new Core.Field(rows, cols);

            for (var i = 0; i < rows; i++)
            {
                field.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                for (var j = 0; j < cols; j++)
                {
                    field.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    var cell = new Controls.Cell(i, j, coreField);
                    cell.Name = string.Format("c{0}{1}", i, j);

                    cell.SetValue(Grid.RowProperty, i);
                    cell.SetValue(Grid.ColumnProperty, j);
                    cell.text.Visibility = Visibility.Hidden;
                    field.Children.Add(cell);
                    cells.Add(cell);
                }
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            foreach(var cell in cells)
            {
                cell.text.Visibility = Visibility.Visible;
            }
        }
    }
}

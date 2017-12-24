using MNSWPR.App.Controls;
using MNSWPR.App.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Core.Field coreField;
        private List<Controls.Cell> cells = new List<Controls.Cell>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeField();
        }

        public Core.Field Field
        {
            get
            {
                return coreField;
            }
        }

        public bool FirstStepDone { get; set; }

        private void InitializeField()
        {
            var rows = 10;
            var cols = 10;
            var mineCount = 11;

            coreField = new Core.Field(rows, cols, mineCount);

            for (var i = 0; i < rows; i++)
            {
                field.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                for (var j = 0; j < cols; j++)
                {
                    field.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    var cell = new Cell(i, j, this);
                    cell.Name = string.Format("c{0}{1}", i, j);

                    cell.SetValue(Grid.RowProperty, i);
                    cell.SetValue(Grid.ColumnProperty, j);
                    cell.text.Visibility = Visibility.Hidden;
                    field.Children.Add(cell);
                    cell.EmptyCellClicked += OnEmptyCellClicked;
                    cell.MinedCellClicked += OnMinedCellClicked;
                    cells.Add(cell);
                }
            }
        }

        private void OnEmptyCellClicked(Cell clickedCell, EmptyCellClickedEventArgs args)
        {
            var cellsAround = coreField.GetCellsAround(clickedCell.Row, clickedCell.Col);
            var minesAround = cellsAround.Count(x => coreField.Mined(x.Row, x.Col));
            if (minesAround == 0)
            {
                foreach (var coordinates in cellsAround)
                {
                    var cell = cells.Single(x => x.Row == coordinates.Row && x.Col == coordinates.Col);
                    cell.Click();
                }
            }
            else
            {
                clickedCell.text.Text = minesAround.ToString();
                clickedCell.text.Visibility = Visibility.Visible;
            }
        }

        private void OnMinedCellClicked(Cell clickedCell, EmptyCellClickedEventArgs args)
        {
            foreach (var cell in cells)
            {
                cell.MinedCellClicked -= OnMinedCellClicked;
                cell.EmptyCellClicked -= OnEmptyCellClicked;
            }
            foreach(var cell in cells)
            {
                if (coreField.Mined(cell.Row, cell.Col)) //keep mined cells from separate collection?
                {
                    cell.Explode();
                }
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //foreach(var cell in cells)
            //{
            //    cell.text.Visibility = Visibility.Visible;
            //}
            InitializeField();
        }
        private void CellClicked(int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
            InitializeField();
        }

        private void InitializeField()
        {
            for (var i = 0; i < 2; i++)
            {
                for(var j = 0; j < 2; j++)
                {
                    var c = new Controls.Cell();
                    c.Name = string.Format("c{0}{1}", i, j);
                    field.Children.Add(c);
                }
            }
        }
    }
}

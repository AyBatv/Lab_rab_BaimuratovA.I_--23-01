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

namespace Lab_rab_BaimuratovA.I_БПИ_23_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
    }
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int Price { get; set; }


        public double AverageCostOfPafe()
        {
            if (Pages <= 0) return 0;
            return Price / Pages;
        }
    }
}

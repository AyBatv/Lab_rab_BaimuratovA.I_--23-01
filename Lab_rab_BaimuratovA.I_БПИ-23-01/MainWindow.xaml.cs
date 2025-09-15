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


    using System;
    using System.Windows;


    public partial class MainWindow : Window
    {
        private Book currentBook;

        public MainWindow()
        {
            InitializeComponent();
        }

        
            private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                e.Handled = !int.TryParse(e.Text, out _);
            }

            private void NumberOrDot_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                if (!char.IsDigit(e.Text, 0) && e.Text != ",")
                {
                    e.Handled = true;
                }
            }

            private void NoSpace_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Space) e.Handled = true;
            }
        private bool CreateBookFromInput()
        {
            try
            {
                string title = TitleBox.Text;


                if (!int.TryParse(PagesBox.Text, out int pages) || pages <= 0)
                {
                    MessageBox.Show("Введите корректное количество страниц (целое число > 0).");
                    return false;
                }


                if (!double.TryParse(PriceBox.Text, out double price) || price <= 0)
                {
                    MessageBox.Show("Введите корректную цену (число > 0).");
                    return false;
                }

                currentBook = new Book(title, pages, price);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при вводе данных!");
                return false;
            }
        }


        private void Avg_Price_Click(object sender, RoutedEventArgs e)
        {
            if (!CreateBookFromInput()) return;

            double cost = currentBook.AverageCostOfPage();
            ResultBlock.Text = $"Цена книги: {currentBook.Price:F2} руб.\n" +
                               $"Средняя стоимость страницы: {cost:F2} руб.";
        }


        private void Check_Title_Click(object sender, RoutedEventArgs e)
        {
            if (!CreateBookFromInput()) return;

            string checkWord = CheckWordBox.Text.Trim();
            if (string.IsNullOrEmpty(checkWord))
            {
                MessageBox.Show("Введите слово для проверки!");
                return;
            }

            double oldPrice = currentBook.Price;
            currentBook.IfStartDouble(checkWord);

            double cost = currentBook.AverageCostOfPage();

            if (currentBook.Price > oldPrice)
            {
                ResultBlock.Text = $"Название начинается с \"{checkWord}\" → цена удвоена!\n" +
                                   $"Новая цена книги: {currentBook.Price:F2} руб.\n" +
                                   $"Средняя стоимость страницы: {cost:F2} руб.";
            }
            else
            {
                ResultBlock.Text = $"Название не начинается с \"{checkWord}\" → цена без изменений.\n" +
                                   $"Цена книги: {currentBook.Price:F2} руб.\n" +
                                   $"Средняя стоимость страницы: {cost:F2} руб.";
            }
        }
    }
}



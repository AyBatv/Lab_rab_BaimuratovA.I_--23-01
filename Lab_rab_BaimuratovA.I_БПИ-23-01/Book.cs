using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_BaimuratovA.I_БПИ_23_01
{
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }

        public Book(string title, int pages, double price)
        {
            Title = title;
            Pages = pages;
            Price = price;
        }

        public double AverageCostOfPage()
        {
            if (Pages <= 0) return 0;
            return Price / Pages;
        }

        public void IfStartDouble(string word)
        {
            if (Title.StartsWith(word))
            {
                Price *= 2;
            }
        }
    }
}

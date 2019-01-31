using BookShop.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Core
{
    public class Engine
    {
        public void Run()
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            try
            {
                Book book = new Book(title, author, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(title, author, price);

                Console.WriteLine(book + Environment.NewLine);          
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

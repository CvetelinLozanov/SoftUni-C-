using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace _06.Book_Library_Modification
{
    class Program
    {
        static void Main()
        {
            int numOfBooks = int.Parse(Console.ReadLine());
            List<Book> books = ReadBooks(numOfBooks);
            string date = Console.ReadLine();
            DateTime specialDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var filteredBooks = books.Where(b => b.ReleaseDate > specialDate).ToList();
            foreach (var book in filteredBooks.OrderBy(b => b.ReleaseDate).ThenBy(b => b.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
            }
        }

        private static List<Book> ReadBooks(int numOfBooks)
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < numOfBooks; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                DateTime date = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string isbn = input[4];
                decimal price = decimal.Parse(input[5]);
                Book book = new Book
                {
                    Title = title,
                    Author = author,
                    Publisher = publisher,
                    ReleaseDate = date,
                    Isbn = isbn,
                    Price = price,
                };
                books.Add(book);
            }
            return books;
        }
    }  

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
    }
}
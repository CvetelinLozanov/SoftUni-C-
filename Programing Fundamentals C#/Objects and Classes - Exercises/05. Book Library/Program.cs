using System;
using System.Linq;
using System.Collections.Generic;


namespace _05.Book_Library
{
    class Program
    {
        static void Main()
        {
            var booksPrice = new Dictionary<string, decimal>();
            int numOfBooks = int.Parse(Console.ReadLine());
            List<Book> books = ReadBooks(numOfBooks);
            foreach (var book in books)
            {
                if (!booksPrice.ContainsKey(book.Author))
                {
                    booksPrice.Add(book.Author, book.Price);
                }
                else
                {
                    booksPrice[book.Author] += book.Price; 
                }
            }
            foreach (var book in booksPrice.OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{book.Key} -> {book.Value:F2}");
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
                string date = input[3];
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
        public string  Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
    }  
}
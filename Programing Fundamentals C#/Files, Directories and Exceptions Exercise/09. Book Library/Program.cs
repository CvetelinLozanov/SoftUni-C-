using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _09.Book_Library
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Book> books = ReadBooks(input);
            File.Delete("output.txt");
            Library library = new Library
            {
                Name = "Prosveta",
                Books = books,
            };
            var authorSales = library.Books
                .Select(a => a.Author)
                .Distinct()
                .Select(author => new AuthorInfo
                {
                    Name = author,
                    Sales = library.Books.Where(book => book.Author == author).Sum(b => b.Price)
                })
                .OrderByDescending(b => b.Sales)
                .ThenBy(b => b.Name).ToArray();
            foreach (var book in authorSales)
            {
                File.AppendAllText("output.txt", $"{book.Name} -> {book.Sales}{Environment.NewLine}");
            }
        }

        private static List<Book> ReadBooks(string[] input)
        {
            int n = int.Parse(input[0]);
            string[] bookArgs = input.Skip(1).ToArray();
            List<Book> books = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = bookArgs[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string title = tokens[0];
                string author = tokens[1];
                string publisher = tokens[2];
                string realeseDate = tokens[3];
                string isbn = tokens[4];
                decimal price = decimal.Parse(tokens[5]);
                Book book = new Book
                {
                    Author = author,
                    Isbn = isbn,
                    Price = price,
                    Publisher = publisher,
                    RealiseDate = realeseDate,
                    Title = title,
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

        public string RealiseDate { get; set; }

        public string Isbn { get; set; }

        public decimal Price { get; set; }
    }

    public class Library
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }

    public class AuthorInfo
    {
        public string Name { get; set; }

        public Decimal Sales { get; set; }
    }
}
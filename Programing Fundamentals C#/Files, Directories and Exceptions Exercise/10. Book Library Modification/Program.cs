using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace _10.Book_Library_Modification
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            File.Delete("output.txt");
            List<Book> books = ReadBooks(input);
            DateTime specialDate = DateTime.ParseExact(input[input.Length - 1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var filteredBooks = books.Where(book => book.RealiseDate > specialDate)
                .OrderBy(book => book.RealiseDate)
                .ThenBy(book => book.Title)
                .ToList();
            Library library = new Library
            {
                Name = "Prosveta",
                Books = filteredBooks,
            };
            foreach (var book in library.Books)
            {
                File.AppendAllText("output.txt", $"{book.Title} -> {book.RealiseDate:dd.MM.yyyy}{Environment.NewLine}");
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
                DateTime realeseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
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

        public DateTime RealiseDate { get; set; }

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
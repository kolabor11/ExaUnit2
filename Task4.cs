using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Book
{
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
    
        List<Book> booksData;
        using (StreamReader r = new StreamReader("books.json"))
        {
            string json = r.ReadToEnd();
            booksData = JsonConvert.DeserializeObject<List<Book>>(json);
        }

        // Function to return only books starting with "The"
        List<Book> BooksStartingWithThe(List<Book> books)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (book.Title.StartsWith("The"))
                {
                    result.Add(book);
                }
            }
            return result;
        }

        // Function to return only books written by authors with a 't' in their name
        List<Book> BooksByAuthorsWithT(List<Book> books)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (book.Author.ToLower().Contains("t"))
                {
                    result.Add(book);
                }
            }
            return result;
        }

        // Function to count the number of books written after a given year
        int BooksWrittenAfterYear(List<Book> books, int year)
        {
            int count = 0;
            foreach (var book in books)
            {
                if (book.PublicationYear > year)
                {
                    count++;
                }
            }
            return count;
        }

        // Function to count the number of books written before a given year
        int BooksWrittenBeforeYear(List<Book> books, int year)
        {
            int count = 0;
            foreach (var book in books)
            {
                if (book.PublicationYear < year)
                {
                    count++;
                }
            }
            return count;
        }

        // Function to return the ISBN numbers of all books by a given author
        List<string> IsbnNumbersByAuthor(List<Book> books, string authorName)
        {
            List<string> isbns = new List<string>();
            foreach (var book in books)
            {
                if (book.Author.Contains(authorName))
                {
                    isbns.Add(book.Isbn);
                }
            }
            return isbns;
        }

        // Function to list books alphabetically in ascending or descending order
        List<Book> ListBooksAlphabetically(List<Book> books, bool ascending = true)
        {
            if (ascending)
            {
                books.Sort((x, y) => string.Compare(x.Title, y.Title));
            }
            else
            {
                books.Sort((x, y) => string.Compare(y.Title, x.Title));
            }
            return books;
        }

        // Function to list books chronologically in ascending or descending order
        List<Book> ListBooksChronologically(List<Book> books, bool ascending = true)
        {
            if (ascending)
            {
                books.Sort((x, y) => x.PublicationYear.CompareTo(y.PublicationYear));
            }
            else
            {
                books.Sort((x, y) => y.PublicationYear.CompareTo(x.PublicationYear));
            }
            return books;
        }

        // Function to group books by author last name
        Dictionary<string, List<Book>> GroupBooksByAuthorLastName(List<Book> books)
        {
            Dictionary<string, List<Book>> groupedBooks = new Dictionary<string, List<Book>>();
            foreach (var book in books)
            {
                string[] authorNameParts = book.Author.Split(' ');
                string lastName = authorNameParts[authorNameParts.Length - 1];
                if (!groupedBooks.ContainsKey(lastName))
                {
                    groupedBooks[lastName] = new List<Book>();
                }
                groupedBooks[lastName].Add(book);
            }
            return groupedBooks;
        }

        // Function to group books by author first name
        Dictionary<string, List<Book>> GroupBooksByAuthorFirstName(List<Book> books)
        {
            Dictionary<string, List<Book>> groupedBooks = new Dictionary<string, List<Book>>();
            foreach (var book in books)
            {
                string[] authorNameParts = book.Author.Split(' ');
                string firstName = authorNameParts[0];
                if (!groupedBooks.ContainsKey(firstName))
                {
                    groupedBooks[firstName] = new List<Book>();
                }
                groupedBooks[firstName].Add(book);
            }
            return groupedBooks;
        }
    }
}    

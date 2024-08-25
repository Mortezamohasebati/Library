using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author, double price, int pages)
        {
            Title = title;
            Author = author;
            Price = price;
            Pages = pages;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}, Price: {Price}, Pages: {Pages}";
        }
    }

    public class Librarian
    {
        private List<Book> _books;

        public Librarian()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            try
            {
                _books.Add(book);
                Console.WriteLine($"Book '{book.Title}' added to the library.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
            }
        }

        public void RemoveBook(string title)
        {
            try
            {
                var bookToRemove = _books.Find(b => b.Title == title);
                if (bookToRemove != null)
                {
                    _books.Remove(bookToRemove);
                    Console.WriteLine($"Book '{title}' removed from the library.");
                }
                else
                {
                    Console.WriteLine($"Book '{title}' not found in the library.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing book: {ex.Message}");
            }
        }

        public List<Book> GetBooks()
        {
            return _books;
        }
    }

    public class BookReader
    {
        private ShoppingCart _cart;

        public BookReader()
        {
            _cart = new ShoppingCart();
        }

        public void ViewBooks(List<Book> books)
        {
            try
            {
                if (books == null || books.Count == 0)
                {
                    Console.WriteLine("No books available in the library.");
                    return;
                }

                Console.WriteLine("Available Books:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing books: {ex.Message}");
            }
        }

        public void AddBookToCart(Book book)
        {
            try
            {
                if (book == null)
                {
                    Console.WriteLine("Invalid book.");
                    return;
                }

                _cart.AddBook(book);
                Console.WriteLine($"Book '{book.Title}' added to your shopping cart.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book to cart: {ex.Message}");
            }
        }

        public void ViewCart()
        {
            try
            {
                _cart.ViewCart();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing cart: {ex.Message}");
            }
        }
    }

    public class ShoppingCart
    {
        private List<Book> _books;

        public ShoppingCart()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            try
            {
                _books.Add(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book to cart: {ex.Message}");
            }
        }
        public void ViewCart()
        {
            try
            {
                if (_books == null || _books.Count == 0)
                {
                    Console.WriteLine("Your shopping cart is empty.");
                    return;
                }

                Console.WriteLine("Your Shopping Cart:");
                double total = 0;
                foreach (var book in _books)
                {
                    Console.WriteLine(book);
                    total += book.Price;
                }
                Console.WriteLine($"Total Price: {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing cart: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Librarian librarian = new Librarian();
                BookReader reader = new BookReader();

                while (true)
                {
                    Console.WriteLine("\n--- Main Menu ---");
                    Console.WriteLine("1. Book Operations");
                    Console.WriteLine("2. Book Reader Operations");
                    Console.WriteLine("3. Librarian Operations");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option: ");
                    string mainChoice = Console.ReadLine();

                    switch (mainChoice)
                    {
                        case "1":
                            BookOperations(librarian);
                            break;
                        case "2":
                            ReaderOperations(reader, librarian);
                            break;
                        case "3":
                            LibrarianOperations(librarian);
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        static void BookOperations(Librarian librarian)
        {
            try
            {
                Console.WriteLine("\n--- Book Operations ---");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.WriteLine("3. View all books");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(librarian);
                        break;
                    case "2":
                        RemoveBook(librarian);
                        break;
                    case "3":
                        ViewBooks(librarian.GetBooks());
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in book operations: {ex.Message}");
            }
        }

        static void ReaderOperations(BookReader reader, Librarian librarian)
        {
            try
            {
                Console.WriteLine("\n--- Book Reader Operations ---");
                Console.WriteLine("1. View available books");
                Console.WriteLine("2. Add a book to cart");
                Console.WriteLine("3. View shopping cart");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        reader.ViewBooks(librarian.GetBooks());
                        break;
                    case "2":
                        AddBookToCart(librarian, reader);
                        break;
                    case "3":
                        reader.ViewCart();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in reader operations: {ex.Message}");
            }
        }

        static void LibrarianOperations(Librarian librarian)
        {
            try
            {
                Console.WriteLine("\n--- Librarian Operations ---");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Remove a book");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(librarian);
                        break;
                    case "2":
                        RemoveBook(librarian);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in librarian operations: {ex.Message}");
            }
        }

        static void AddBook(Librarian librarian)
        {
            try
            {
                Console.Write("Enter book title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author name: ");
                string author = Console.ReadLine();
                Console.Write("Enter price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter number of pages: ");
                int pages = int.Parse(Console.ReadLine());

                Book book = new Book(title, author, price, pages);
                librarian.AddBook(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
            }
        }

        static void RemoveBook(Librarian librarian)
        {
            try
            {
                Console.Write("Enter the title of the book to remove: ");
                string title = Console.ReadLine();
                librarian.RemoveBook(title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing book: {ex.Message}");
            }
        }

        static void AddBookToCart(Librarian librarian, BookReader reader)
        {
            try
            {
                Console.Write("Enter the title of the book to add to cart: ");
                string title = Console.ReadLine();
                Book book = librarian.GetBooks().Find(b => b.Title == title);
                reader.AddBookToCart(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book to cart: {ex.Message}");
            }
        }

        static void ViewBooks(List<Book> books)
        {
            try
            {
                if (books == null || books.Count == 0)
                {
                    Console.WriteLine("No books available in the library.");
                    return;
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}

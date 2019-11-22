using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProjectSep2019
{
    public static class Library
    {
        private static LibraryContext db = new LibraryContext();
        public static Customer CustomerInformation(string CustomerName,
          string PhoneNumber,
          string Email,
          string Address)
        {
            var customer = new Customer
            {
                CustomerName = CustomerName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Address = Address
            };

            if (PhoneNumber.Length < 10)
            {
                Console.WriteLine("Phone Number Invalid");
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;

        }
        public static void IssueBook(string email, string bookName)
        {
            var book = db.Books.SingleOrDefault(a => a.BookName == bookName);

            if (book == null)
            {
                // Throw exception
                return;
            }
            var customer = db.Customers.SingleOrDefault(a => a.Email == email);

            if (customer == null)
            {
                return;
            }

            if (book.IssuedUserID != 0)
            {
                throw new InvalidOperationException("The book is already issued");
            }

            book.IssueBook(customer.UserIDOfCustomer);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.bookIssue,
                Description = "book Issue",
                IsbnNumber = book.IsbnNumber,
                UserIDOfCustomer = customer.UserIDOfCustomer
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void ReturnBook(string bookName)
        {
            var book = db.Books.SingleOrDefault(a => a.BookName == bookName);

            if(book == null)
            {               
                return;
            }

            var customerID = book.IssuedUserID;
            book.ReturnBook();

            var Trasaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.bookReturn,
                Description = "book return",
                IsbnNumber = book.IsbnNumber,
                UserIDOfCustomer = customerID
            };

            db.Transactions.Add(Trasaction);
            db.SaveChanges();
        }
        public static IEnumerable<Customer> GetAllCustomers()
        {
            return db.Customers;
        }

        public static IEnumerable<Customer> GetAllCustomersByEmail(string email)
        {
            return db.Customers.Where(a => a.Email == email);
        }

        public static Book GetBookByIsbnNumber(string isbnNumber)
        {
            return db.Books.Find(isbnNumber);
        }

        public static void UpdateBook(Book updatedBook)
        {
            var oldBook = GetBookByIsbnNumber(updatedBook.IsbnNumber);
            oldBook.BookName = updatedBook.BookName;
            oldBook.BooksCategory = updatedBook.BooksCategory;
            oldBook.IssuedUserID = updatedBook.IssuedUserID;
            oldBook.IssuedDate = updatedBook.IssuedDate;
            oldBook.ReplacementPrice = updatedBook.ReplacementPrice;
            db.SaveChanges();
        } 

        public static void UpdateCustomer(Customer updatedCustomer)
        {
            var oldCustomer = GetCustomerByUserID(updatedCustomer.UserIDOfCustomer);
            oldCustomer.CustomerName = updatedCustomer.CustomerName;
            oldCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            oldCustomer.Email = updatedCustomer.Email;
            oldCustomer.Address = updatedCustomer.Address;
            db.SaveChanges();
        }
        public static Customer GetCustomerByUserID(int userID)
        {
            return db.Customers.Find(userID);
        }

        public static IEnumerable<Transaction> GetAllTransactionByEmail(string email)
        {
            var customer = db.Customers.SingleOrDefault(a => a.Email == email);

            if (customer == null)
            {
                return null;
            }
            return db.Transactions.Where(t => t.UserIDOfCustomer == customer.UserIDOfCustomer)
                               .OrderByDescending(t => t.TransactionDate);
        }

        public static Book BookInformation(string BookName,
            string ISBNNumber,
            TypeOfBooks BooksCategory = TypeOfBooks.Fiction,
            decimal replacementPrice = 0)
        {
            var book = new Book
            {
                BookName = BookName,
                IsbnNumber = ISBNNumber,
                BooksCategory = BooksCategory,
                ReplacementPrice = replacementPrice
            };
            db.Books.Add(book);
            db.SaveChanges();

            return book;
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            return db.Books;
        }

        public static IEnumerable<Book> GetAllBooksByName(string bookName)
        {
            return db.Books.Where(a => a.BookName == bookName);
        }
    }
}


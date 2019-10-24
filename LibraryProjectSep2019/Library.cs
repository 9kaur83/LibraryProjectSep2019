using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProjectSep2019
{
   static class Library
    {
        private static List<Customer> Customers = new List<Customer>();
        private static List<Transaction> Transactions = new List<Transaction>();
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

            Customers.Add(customer);

            return customer;

        }
        public static void IssueBook(string email, string bookName)
        {
            var book = Books.SingleOrDefault(a => a.BookName == bookName);

            if (book == null)
            {
                // Throw exception
                return;
            }
            var customer = Customers.SingleOrDefault(a => a.Email == email);

            if (customer == null)
            {
                return;
            }

            book.IssueBook(customer.UserIDOfCustomer);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.bookIssue,
                Description = "book Issue",
                BookName = book.BookName,
                UserIDOfCustomer = customer.UserIDOfCustomer
            };

            Transactions.Add(transaction);
        }

        public static void ReturnBook(string bookName)
        {
            var book = Books.SingleOrDefault(a => a.BookName == bookName);

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
                BookName = book.BookName,
                UserIDOfCustomer = customerID
            };

            Transactions.Add(Trasaction);
        }
        public static IEnumerable<Customer> GetAllCustomers()
        {
            return Customers;
        }
        public static IEnumerable<Customer> GetAllCustomersByEmail(string email)
        {
           return Customers.Where(a => a.Email == email);
        }
      
        private static List<Book> Books = new List<Book>();
        public static Book BookInformation(string BookName,
            string ISBNNumber,
            TypeOfBooks BooksCategory,
            decimal replacementPrice)
        {
            var book = new Book
            {
                BookName = BookName,
                IsbnNumber = ISBNNumber,
                BooksCategory = BooksCategory,
                ReplacementPrice = replacementPrice
            };
            Books.Add(book);

            return book;
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        public static IEnumerable<Book> GetAllBooksByName(string bookName)
        {
            return Books.Where(a => a.BookName == bookName);
        }
    }
}


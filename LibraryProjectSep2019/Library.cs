using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProjectSep2019
{
   static class Library
    {
        private static List<Customer> Customers = new List<Customer>();
        public static Customer CustomerInformation(string CustomerName,
          string PhoneNumber,
          string Email,
          string Address)
        {
            var Customer = new Customer
            {
                CustomerName = CustomerName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Address = Address
            };
            if (PhoneNumber.Length < 10)
            {
                Console.WriteLine("Phone Number Invalid");
            };
            Customers.Add(Customer);
            return Customer;

        }
        public static IEnumerable<Customer> GetAllCustomersByEmail(string Email)
        {
           return Customers.Where(a => a.Email == Email);
        }
      
        private static List<Book> Books = new List<Book>();
        public static Book BookInformation(string BookName,
            string ISBNNumber,
            TypeOfBooks BooksCategory,
            decimal replacementPrice)
        {
            var Book = new Book
            {
                BookName = BookName,
                IsbnNumber = ISBNNumber,
                BooksCategory = BooksCategory,
                ReplacementPrice = replacementPrice
            };
            Books.Add(Book);
            return Book;
        }

      

    }
    


}


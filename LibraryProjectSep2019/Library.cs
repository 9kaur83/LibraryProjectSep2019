using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProjectSep2019
{
   static class Library
    {
        public static Customer CustomerInformation(string CustomerName,
            string PhoneNumber,
            string Email,
            string Address)
        {
            var Customer = new Customer
            {
                CustomerName = CustomerName,
                PhoneNumber = PhoneNumber,
                Email =Email,
                Address =Address
            };
            if(PhoneNumber.Length < 10)
            {
                Console.WriteLine("InvalidNumber");
            }
            return Customer;
        }
        public static Book BookInformation(string BookName,
            string ISBNNumber,
            TypeOfBooks BooksCategory)
        {
            var Book = new Book
            {
                BookName = BookName,
                IsbnNumber = ISBNNumber,
                BooksCategory =BooksCategory
            };
            return Book;
        }
    }
    


}

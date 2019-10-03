using Stripe;
using System;
using Twilio.Types;

namespace LibraryProjectSep2019
{
    class ProgramC
    {
        static void Main(string[] args)
        {
            var customer = new Customer
            {
                CustomerName = "raj",
                PhoneNumber = "98765437",
                Email = "hjy@gmail.com",
                Address = "34, DR SE bothell"
            };

            Console.WriteLine($"CN:{customer.CustomerName}" +
                $",PN:{customer.PhoneNumber}" +
                $",Email:{customer.Email}" +
                $",address:{customer.Address}" +
                $",UsID:{customer.UserIDOfCustomer}");

            var customer2 = new Customer
            {
                CustomerName = "test",
                PhoneNumber = "98765439",
                Email = "abc@gmail.com",
                Address = "Hwy st, Valley"
            };

            Console.WriteLine($"CN:{customer2.CustomerName}" +
                $",PN:{customer2.PhoneNumber}" +
                $",Email:{customer2.Email}" +
                $",address:{customer2.Address}" +
                $",UsID:{customer2.UserIDOfCustomer}");

            var book = new Book
            {
                BookName = "abc",
                IsbnNumber = "9865558"
            };
      
            Console.WriteLine($"BN:{book.BookName}" +
                $",IN:{book.IsbnNumber}" +
                $",Issued:{book.IssuedUserID != 0}");

            book.IssueBook(customer.UserIDOfCustomer);

            Console.WriteLine($"BN:{book.BookName}" +
                $",IN:{book.IsbnNumber}" +
                $",Issued:{book.IssuedUserID != 0}" +
                $",IssuedDate:{book.IssueDate}" +
                $",IssuedByUserId:{book.IssuedUserID}");

            book.ReturnBook();

            Console.WriteLine($"BN:{book.BookName}" +
                $",IN:{book.IsbnNumber}" +
                $",Issued:{book.IssuedUserID != 0}" +
                $",IssuedDate:{book.IssueDate}");
        }
    }
}


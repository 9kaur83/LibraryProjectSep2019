using Stripe;
using System;
using Twilio.Types;

namespace LibraryProjectSep2019
{
    class Program
    {
        static void Main(string[] args)
        {
           var customer = Library.CustomerInformation("raj", "98765437", "hjml@gmail.com", "ln sn 7865");

            Console.WriteLine($"CN:{customer.CustomerName}" +
                $",PN:{customer.PhoneNumber}" +
                $",Email:{customer.Email}" +
                $",address:{customer.Address}" +
                $",UsID:{customer.UserIDOfCustomer}");

            var customer2 = Library.CustomerInformation("sam", "98765439", "abc@gmail.com", "Hwy st, Valley");

            Console.WriteLine($"CN:{customer2.CustomerName}" +
                $",PN:{customer2.PhoneNumber}" +
                $",Email:{customer2.Email}" +
                $",address:{customer2.Address}" +
                $",UsID:{customer2.UserIDOfCustomer}");

            var Book = Library.BookInformation("klm", "988670", TypeOfBooks.Horror);

            Console.WriteLine($"BN:{Book.BookName}" +
            $",IN:{Book.IsbnNumber}" +
            $",Issued:{Book.IssuedUserID != 0}");

            Book.IssueBook(customer.UserIDOfCustomer);

            Console.WriteLine($"BN:{Book.BookName}" +
                $",IN:{Book.IsbnNumber}" +
                $",Issued:{Book.IssuedUserID != 0}" +
                $",IssuedDate:{Book.IssueDate}" +
                $",IssuedByUserId:{Book.IssuedUserID}" +
                $",BC:{Book.BooksCategory}");

            Book.ReturnBook();

            Console.WriteLine($"BN:{Book.BookName}" +
                $",IN:{Book.IsbnNumber}" +
                $",Issued:{Book.IssuedUserID != 0}" +
                $",IssuedDate:{Book.IssueDate}," +
                $",IssuedByUserId:{Book.IssuedUserID}," +
                $"BC:{Book.BooksCategory}");

        }
    }
}


using Stripe;
using System;
using Twilio.Types;

namespace LibraryProjectSep2019
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("********Library App!**********");

            while (true)
            {

                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Enter a new book");
                Console.WriteLine("2. Issue a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. Search a book");
                Console.WriteLine("5. Find a book issued to a user ");
                Console.WriteLine("6. Replacement Price");
                Console.WriteLine("7. Print all books");
                Console.WriteLine("8. Add Customer");
                Console.WriteLine("9. Search Customer By Email");
                Console.WriteLine("10 Print all customer");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank You For Visting");
                        return;
                    case "1":
                        Console.Write("BookName:");
                        var Name = Console.ReadLine();
                        Console.Write("IsbnNumber:");
                        var Number = Console.ReadLine();
                        Console.WriteLine("Books Category:");
                        //convert enum to array
                        var BooksCategory =
                              Enum.GetNames(typeof(TypeOfBooks));

                        //Loop through the array and print out
                        for (var i = 0; i < BooksCategory.Length; i++)
                        {
                            Console.WriteLine($"{i}.{BooksCategory[i]}");
                        }
                        var bookType = Enum.Parse<TypeOfBooks>(Console.ReadLine());

                        Console.Write("price: ");
                        var replacementAmount = Convert.ToDecimal(Console.ReadLine());

                        var book = Library.BookInformation(Name, Number, bookType, replacementAmount);
                        Console.WriteLine($"BN:{book.BookName}" +
                            $",IN:{book.IsbnNumber}" +
                            $",BC:{book.BooksCategory}" +
                            $",RP" +
                            $":{book.ReplacementPrice:c}");

                        break;
                    case "2":
                        CheckOutBook();

                        break;
                    case "3":
                        ReturnBook();
                        break;
                    case "4":
                        PrintAllBooks();

                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        Console.Write("Book Name:");
                        var BookName = Console.ReadLine();
                        var Books = Library.GetAllBooksByName(BookName);
                        foreach (var Book in Books)
                        {
                            Console.WriteLine($"BN:{Book.BookName}" +
                            $",IN:{Book.IsbnNumber}" +
                            $",BC:{Book.BooksCategory}" +
                            $",IssuedByUserId:{ Book.IssuedUserID}" +
                            $",IssuedDate:{Book.IssuedDate}");
                        }
                         break;
                    case "8":
                        Console.Write("Customer Name:");
                        var CustomerName = Console.ReadLine();
                        Console.Write("Phone Number:");
                        var PhoneNumber = Console.ReadLine();
                        Console.Write("Email:");
                        var customerEmail = Console.ReadLine();
                        Console.Write("Address:");
                        var Address = Console.ReadLine();
                        var customer = Library.CustomerInformation(CustomerName, PhoneNumber, customerEmail, Address);
                        Console.WriteLine($"CN:{customer.CustomerName}" +
                            $",PN:{customer.PhoneNumber}" +
                            $",EM:{customer.Email}" +
                            $",AD:{customer.Address}");
                        break;
                    case "9":
                        SearchCustomerByEmail();

                        break;
                    case "10":
                        Console.Write("Customer Email:");
                        var searchEmail = Console.ReadLine();
                        var Customers = Library.GetAllCustomersByEmail(searchEmail);
                        foreach (var customer1 in Customers)
                        {
                            Console.WriteLine($"CN:{customer1.CustomerName}" +
                            $",PN:{customer1.PhoneNumber}" +
                            $",EM:{customer1.Email}" +
                            $",AD:{customer1.Address}");
                        }

                            break;

                    default:
                        Console.WriteLine("Please Select A Valid Option");
                        break;

                }
            }
        }

        private static void SearchCustomerByEmail()
        {
            Console.Write("Enter Customer Email:");
            var searchEmail = Console.ReadLine();
            var customers = Library.GetAllCustomersByEmail(searchEmail);
            foreach (var customer in customers)
            {
                Console.WriteLine($"CN:{customer.CustomerName}" +
                    $",PN:{customer.PhoneNumber}" +
                    $",EM:{customer.Email}" +
                    $",AD:{customer.Address}");
            }
        }

        private static void ReturnBook()
        {
            Console.Write("Enter book name:");
            var bookName = Console.ReadLine();
            Library.ReturnBook(bookName);
            PrintAllBooks(bookName);
        }

        private static void CheckOutBook()
        {
            Console.Write("Enter Book Name:");
            var bookName = Console.ReadLine();
            Console.Write("Enter Email:");
            var email = Console.ReadLine();
            Library.IssueBook(email, bookName);
            PrintAllBooks(bookName);
        }

        private static void PrintAllBooks(string bookName = null)
        {
            if (bookName == null)
            {
                Console.Write(" Book Name:");
                bookName = Console.ReadLine();
            }

            var Books = Library.GetAllBooksByName(bookName);
            foreach (var book in Books)
            {
                Console.WriteLine($"BN:{book.BookName}" +
                    $",IN:{book.IsbnNumber}" +
                    $",BC:{book.BooksCategory}" +
                    $",IssuedByUserId:{ book.IssuedUserID}"+
                    $",IssuedDate:{book.IssuedDate}");
            }
        }
    }
}


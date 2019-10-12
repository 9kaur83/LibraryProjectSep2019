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
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        Console.Write("Customer Name:");
                        var CustomerName = Console.ReadLine();
                        Console.Write("Phone Number:");
                        var PhoneNumber = Console.ReadLine();
                        Console.Write("Email:");
                        var Email = Console.ReadLine();
                        Console.Write("Address:");
                        var Address = Console.ReadLine();
                        var Customer = Library.CustomerInformation(CustomerName,PhoneNumber,Email,Address);
                        Console.WriteLine($"CN:{Customer.CustomerName}" +
                            $",PN:{Customer.PhoneNumber}" +
                            $",EM:{Customer.Email}" +
                            $",AD:{Customer.Address}");
                        break;
                    case "9":
                        Console.Write("Enter Customer Email:");
                        var SearchEmail = Console.ReadLine();
                        var customers = Library.GetAllCustomersByEmail(SearchEmail);
                        foreach(Customer customer in customers)
                        {
                            Console.WriteLine($"CN:{customer.CustomerName}" +
                                $",PN:{customer.PhoneNumber}" +
                                $",EM:{customer.Email}" +
                                $",AD:{customer.Address}");
                        }

                        break;



                        
                    default:
                        Console.WriteLine("Please Select A Valid Option");
                        break;

                }
            }

            /* var customer = Library.CustomerInformation("raj", "98765437", "hjml@gmail.com", "ln sn 7865");

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
                 $"BC:{Book.BooksCategory}"); */


        }
    }
}


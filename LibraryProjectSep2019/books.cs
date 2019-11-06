﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProjectSep2019
{
    public enum TypeOfBooks 
    {
        Poetry,
        Fiction,
        Science,
        Horror,
        History
    }
    
    public class Book
    {
        #region Properties
        /// <summary>
        /// Name of the Book.
        /// </summary>
        public  string BookName { get; set; }
        /// <summary>
        /// ISBN number of the Book.
        /// </summary>
        public string IsbnNumber { get; set; }
        /// <summary>
        /// User ID of the customer who issued the Book. 0 indicates  Book not issued.
        /// </summary>
        public int IssuedUserID { get; set; }
        /// <summary>
        /// Date and time book issued.
        /// </summary>
        public  DateTime IssuedDate { get; set; }
        /// <summary>
        /// All books Category.
        /// </summary>
        public TypeOfBooks BooksCategory { get; set; }
        /// <summary>
        /// price,if book is lost by customer.
        /// </summary>
        public decimal ReplacementPrice { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Book class
        /// </summary>
        public Book()
        {
            IssuedUserID = 0;
            IssuedDate = DateTime.MaxValue;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method to Issue Book to particular user from Library.
        /// </summary>
        /// <param name="userId">User ID of customer that wants to issue the Book</param>
        public void IssueBook(int userId)
        {
            IssuedUserID = userId;
            IssuedDate = DateTime.Now;
        }

        /// <summary>
        /// Method to return Book back to Library
        /// </summary>
        public void ReturnBook()
        {
            IssuedUserID = 0;
            IssuedDate = DateTime.MaxValue;
        }

        internal static void BookInformation(object bookName, object isbnNumber, object issuedUserID, object issuedDate, string[] booksCategory)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
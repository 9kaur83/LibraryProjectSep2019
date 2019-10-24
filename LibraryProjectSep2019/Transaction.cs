﻿using System;

namespace LibraryProjectSep2019
{
    enum TypeOfTransaction
    {
        bookIssue,
        bookReturn
    }


    class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public TypeOfTransaction TransactionType { get; set; }
        public string BookName { get; set; }
        public int UserIDOfCustomer { get; set; }
    }
}






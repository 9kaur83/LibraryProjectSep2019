using System;

namespace LibraryProjectSep2019
{
    public enum TypeOfTransaction
    {
        bookIssue,
        bookReturn
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public TypeOfTransaction TransactionType { get; set; }
        public virtual Book TransactionBook { get; set; }
        public string IsbnNumber { get; set; }
        public virtual Customer TransactionCustomer { get; set; }
        public int UserIDOfCustomer { get; set; }
    }
}






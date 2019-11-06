using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProjectSep2019
{
     public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LibraryOct2019; Integrated Security = True; Connect Timeout = 30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(a => a.IsbnNumber).HasName("PK_IsbnNumber");

                entity.Property(a => a.BookName).IsRequired();

                entity.Property(a => a.IssuedDate).IsRequired();

                entity.Property(a => a.IssuedUserID).IsRequired();

                entity.Property(a => a.ReplacementPrice).IsRequired();

                entity.Property(a => a.BooksCategory).IsRequired();

                entity.ToTable("Books"); 
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(a => a.UserIDOfCustomer).HasName("PK_UserID");

                entity.Property(a => a.UserIDOfCustomer).ValueGeneratedOnAdd();

                entity.Property(a => a.PhoneNumber).IsRequired();

                entity.Property(a => a.Email).IsRequired().HasMaxLength(100);

                entity.ToTable("Customers"); 
            });


            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id).HasName("PK_TransactionID");

                entity.Property(t => t.Id).ValueGeneratedOnAdd();

                entity.Property(t => t.TransactionDate).IsRequired();

                entity.Property(t => t.IsbnNumber).IsRequired();

                entity.Property(t => t.UserIDOfCustomer).IsRequired();

                entity.HasOne(t => t.TransactionBook).WithMany().HasForeignKey(t => t.IsbnNumber);

                entity.HasOne(t => t.TransactionCustomer).WithMany().HasForeignKey(t => t.UserIDOfCustomer);

                entity.ToTable("transactions");
            });
        }      
    }    
}

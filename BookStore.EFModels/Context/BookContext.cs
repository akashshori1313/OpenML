using System;
using System.Collections.Generic;
using System.Text;
using BookStore.EFModels.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EFModels.Context
{
  public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { 
        
          
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=EFCoreBookStoreDb;Integrated Security=SSPI; providerName =System.Data.SqlClient";
        //    //  optionsBuilder.UseSqlServer(connectionString);
        //    //base.OnConfiguring(optionsBuilder);

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        public DbSet<BookDetails> Books { get; set; }
        public DbSet<BuyerDetails> Buyer { get; set; }
    }
}

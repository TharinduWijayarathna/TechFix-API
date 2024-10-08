﻿using Microsoft.EntityFrameworkCore;
using TechFixAPI.Model;
namespace TechFixAPI.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(
            DbContextOptions<AppDBContext> options):base(options)
        { 
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<QuoteRequest> QuoteRequests { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuoteRequestItem> QuoteRequestItems { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().Property(p=>p.Price).
                HasColumnType("decimal(18,2)");
            modelBuilder.Entity<QuotationItem>().Property(p => p.Price).
                HasColumnType("decimal(18,2)");
        }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "Data Source=DESKTOP-SCEAP9U;Initial Catalog=techfix;Integrated Security=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(conn);
        }



    }
}

using Microsoft.EntityFrameworkCore;
using OnlineBookShoping.Models;

namespace OnlineBookShoping.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       public DbSet<Book> Books { get; set; }
       public DbSet<CartDetail> CartDetails { get; set; }
       public DbSet<Genre> Genres { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<OrderDetail> OrderDetails { get; set; }
       public DbSet<OrderStatus> OrderStatuses { get; set; }
       public DbSet<ShoppingCart> ShoppingCarts { get; set; }
       public DbSet<Stock> Stocks { get; set; }
    }
}

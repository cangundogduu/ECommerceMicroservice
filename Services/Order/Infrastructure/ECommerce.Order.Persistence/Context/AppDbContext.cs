using ECommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Order.Persistence.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

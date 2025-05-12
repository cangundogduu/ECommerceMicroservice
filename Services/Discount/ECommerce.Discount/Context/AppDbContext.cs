using ECommerce.Discount.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ECommerce.Discount.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}

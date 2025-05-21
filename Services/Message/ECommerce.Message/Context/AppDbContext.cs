using ECommerce.Message.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Context
{
    public class AppDbContext(DbContextOptions options):DbContext(options)
    {
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}

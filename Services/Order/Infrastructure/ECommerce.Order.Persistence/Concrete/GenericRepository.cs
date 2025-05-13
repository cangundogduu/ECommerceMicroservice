using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Persistence.Concrete
{
    public class GenericRepository<TEntity>(AppDbContext _context) : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> Table = _context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await Table.ToListAsync();
            
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

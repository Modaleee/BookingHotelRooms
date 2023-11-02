using BookingHotelRooms.Models;
using EntityHotelRooms.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAllEntities()
        {
            var rooms = _dbSet;
            return await rooms.ToListAsync();
        }

        public async Task CreateEntity(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}

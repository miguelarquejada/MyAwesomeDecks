using Microsoft.EntityFrameworkCore;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Infrastructure.Data.Context;

namespace MyAwesomeDecks.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T? GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public void DeleteById(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

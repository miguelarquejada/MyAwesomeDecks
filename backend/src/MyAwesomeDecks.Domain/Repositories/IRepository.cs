using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        T? GetById(Guid id);
        Task<T?> GetByIdAsync(Guid id);
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void DeleteById(Guid id);
        Task DeleteByIdAsync(Guid id);
    }
}

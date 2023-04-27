using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Data.Repositories.Interfaces;

public interface ICrudRepository<T> where T: IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
}
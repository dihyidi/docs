using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Business.Services.Interfaces;

public interface IGeneralService<T> where T:IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
}
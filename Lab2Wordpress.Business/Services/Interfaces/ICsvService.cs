using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Business.Services.Interfaces;

public interface ICsvService<T> where T:IEntity
{
    Task<IList<T>> ReadFromCsvAndSaveToDbAsync();
    Task<IList<T>> GenerateAndWriteToCsvAsync();
    Task<IList<T>> GetAllAndWriteToCsvAsync();
}
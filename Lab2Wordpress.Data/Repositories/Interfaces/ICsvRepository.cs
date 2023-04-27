using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Data.Repositories.Interfaces;

public interface ICsvRepository<T> where T: IEntity
{
    Task<IList<T>> ReadFromCsvAndSaveToDbAsync(string path);
    Task<IList<T>> GetAllAndWriteToCsvAsync(string path);
    Task<IList<T>> GenerateWriteToCsvAsync(string path, int count);
}
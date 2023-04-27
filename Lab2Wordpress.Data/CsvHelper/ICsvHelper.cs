using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Data.CsvHelper;

public interface ICsvHelper<T> where T: IEntity
{
    Task<IList<T>> ReadAsync(string path);
    Task<IList<T>> WriteAsync(string path, IList<T> entities);
}
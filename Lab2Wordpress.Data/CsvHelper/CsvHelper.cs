using System.Globalization;
using CsvHelper;
using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Data.CsvHelper;

public class CsvHelper<T> : ICsvHelper<T> where T: IEntity
{
    public async Task<IList<T>> ReadAsync(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        using var streamReader = new StreamReader(path);
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        var csvRecords = csvReader.GetRecordsAsync<T>();

        if (csvRecords is null)
        {
            return null;
        }

        var entities = new List<T>();
        await foreach (var entity in csvRecords)
        {
            entities.Add(entity);
        }

        return entities;
    }

    public async Task<IList<T>> WriteAsync(string path, IList<T> entities)
    {
        if (!entities.Any())
        {
            return null;
        }

        await using var streamWriter = new StreamWriter(path);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        await csvWriter.WriteRecordsAsync(entities);
        return entities;
    }
}
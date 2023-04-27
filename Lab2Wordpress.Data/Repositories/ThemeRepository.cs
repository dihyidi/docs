using Lab2Wordpress.Data.CsvHelper;
using Lab2Wordpress.Data.Entities;
using Lab2Wordpress.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab2Wordpress.Data.Repositories;

public class ThemeRepository : IThemeRepository
{
    private readonly WordpressDbContext dbContext;
    private readonly ICsvHelper<Theme> csvHelper;

    public ThemeRepository(WordpressDbContext dbContext, ICsvHelper<Theme> csvHelper)
    {
        this.dbContext = dbContext;
        this.csvHelper = csvHelper;
    }

    public Task<List<Theme>> GetAllAsync() => this.dbContext.Themes.ToListAsync();

    public Task<Theme> GetByIdAsync(int id) => this.dbContext.Themes.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Theme> CreateAsync(Theme entity) 
    {
       await this.dbContext.Themes.AddAsync(entity);
       await this.dbContext.SaveChangesAsync();

       return entity;
    }

    public async Task UpdateAsync(int id, Theme entity)
    {
        var entityToUpdate = await GetByIdAsync(id);
        if (entityToUpdate is null)
        {
            return;
        }

        entityToUpdate.PrimaryColor = entity.PrimaryColor;
        entityToUpdate.SecondaryColor = entity.SecondaryColor;
        entityToUpdate.Gradient = entity.Gradient;
        
        this.dbContext.Themes.Update(entityToUpdate);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entityToRemove = await GetByIdAsync(id);
        if (entityToRemove is null)
        {
            return;
        }

        this.dbContext.Themes.Remove(entityToRemove);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<IList<Theme>> ReadFromCsvAndSaveToDbAsync(string path)
    {
        var entities = await this.csvHelper.ReadAsync(path);
        if (entities is null || !entities.Any())
        {
            return null;
        }

        foreach (var entity in entities)
        {
            entity.Id = default;
        }

        await this.dbContext.AddRangeAsync(entities);
        await this.dbContext.SaveChangesAsync();
        return entities;
    }

    public async Task<IList<Theme>> GetAllAndWriteToCsvAsync(string path)
    {
        var entities = await GetAllAsync();
        if (entities is null || !entities.Any())
        {
            return null;
        }

        await this.csvHelper.WriteAsync(path, entities);
        return entities;
    }

    public async Task<IList<Theme>> GenerateWriteToCsvAsync(string path, int count)
    {
        var entities = new List<Theme>();
        for (int i = 0; i < count; i++)
        {
            entities.Add(new()
            {
                PrimaryColor = "PrimaryColor" + i,
                SecondaryColor = "SecondaryColor" + i,
                Gradient = "Gradient" + i,
            });
        }
        
        await this.csvHelper.WriteAsync(path, entities);
        return entities;
    }
}
using Lab2Wordpress.Business.Services.Interfaces;
using Lab2Wordpress.Data.Entities;
using Lab2Wordpress.Data.Repositories.Interfaces;

namespace Lab2Wordpress.Business.Services;

public class ThemeService : IThemeService
{
    private const string Filepath = "Themes.csv";
    
    private readonly IThemeRepository themeRepository;

    public ThemeService(IThemeRepository themeRepository)
    {
        this.themeRepository = themeRepository;
    }

    public Task<IList<Theme>> ReadFromCsvAndSaveToDbAsync() => themeRepository.ReadFromCsvAndSaveToDbAsync(Filepath);

    public Task<IList<Theme>> GetAllAndWriteToCsvAsync() => themeRepository.GetAllAndWriteToCsvAsync(Filepath);

    public Task<IList<Theme>> GenerateAndWriteToCsvAsync() => themeRepository.GenerateWriteToCsvAsync(Filepath, 5);

    public Task<List<Theme>> GetAllAsync() => themeRepository.GetAllAsync();

    public Task<Theme> GetByIdAsync(int id) => themeRepository.GetByIdAsync(id);

    public Task<Theme> CreateAsync(Theme entity) => themeRepository.CreateAsync(entity);

    public Task UpdateAsync(int id, Theme entity) => themeRepository.UpdateAsync(id, entity);

    public Task DeleteAsync(int id) => themeRepository.DeleteAsync(id);
}
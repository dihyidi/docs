using Lab2Wordpress.Data.Entities;

namespace Lab2Wordpress.Data.Repositories.Interfaces;

public interface IThemeRepository : ICrudRepository<Theme>, ICsvRepository<Theme>
{
    
}
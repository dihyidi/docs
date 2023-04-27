using Lab2Wordpress.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab2Wordpress.Data;

public sealed class WordpressDbContext : DbContext
{
    public WordpressDbContext(DbContextOptions<WordpressDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Theme> Themes => Set<Theme>();
}
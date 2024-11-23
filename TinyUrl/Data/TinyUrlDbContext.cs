using Microsoft.EntityFrameworkCore;
using TinyUrl.Models;

namespace TinyUrl.Data;

public class TinyUrlDbContext(DbContextOptions<TinyUrlDbContext> options) : DbContext(options)
{
    public DbSet<UrlMapping> UrlMappings { get; init; }
}
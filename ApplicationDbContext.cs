using BBP.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Beer> Beers { get; set; } = null!;
    public DbSet<Brewery> Brewerys { get; set; } = null!;
    public DbSet<Wholesaler> Wholesalers { get; set; } = null!;
    public DbSet<Stock> Stocks { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
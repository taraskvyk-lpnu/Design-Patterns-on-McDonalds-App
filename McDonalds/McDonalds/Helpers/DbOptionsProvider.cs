using System.Configuration;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.Helpers;

public class DbOptionsProvider
{
    private readonly IConfiguration configuration;

    public DbOptionsProvider(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public DbContextOptions<McDonaldsDbContext> GetOptions()
    {
        var optionsBuilder = new DbContextOptionsBuilder<McDonaldsDbContext>();
        optionsBuilder.UseSqlServer(configuration["Connections:DbConnectionString"]);
        return optionsBuilder.Options;
    }
}
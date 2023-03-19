using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Donald.BurgerClub.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BurgerClubDbContextFactory : IDesignTimeDbContextFactory<BurgerClubDbContext>
{
    public BurgerClubDbContext CreateDbContext(string[] args)
    {
        BurgerClubEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BurgerClubDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);

        return new BurgerClubDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Donald.BurgerClub.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Donald.BurgerClub.Data;
using Volo.Abp.DependencyInjection;

namespace Donald.BurgerClub.EntityFrameworkCore;

public class EntityFrameworkCoreBurgerClubDbSchemaMigrator
    : IBurgerClubDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBurgerClubDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BurgerClubDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BurgerClubDbContext>()
            .Database
            .MigrateAsync();
    }
}

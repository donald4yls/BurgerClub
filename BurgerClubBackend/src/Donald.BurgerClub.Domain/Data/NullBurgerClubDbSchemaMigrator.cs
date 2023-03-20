using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Donald.BurgerClub.Data;

/* This is used if database provider does't define
 * IBurgerClubDbSchemaMigrator implementation.
 */
public class NullBurgerClubDbSchemaMigrator : IBurgerClubDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

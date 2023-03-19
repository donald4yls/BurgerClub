using Donald.BurgerClub.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Donald.BurgerClub.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BurgerClubEntityFrameworkCoreModule),
    typeof(BurgerClubApplicationContractsModule)
    )]
public class BurgerClubDbMigratorModule : AbpModule
{

}

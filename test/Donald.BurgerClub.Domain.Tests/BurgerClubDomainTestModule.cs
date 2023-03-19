using Donald.BurgerClub.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Donald.BurgerClub;

[DependsOn(
    typeof(BurgerClubEntityFrameworkCoreTestModule)
    )]
public class BurgerClubDomainTestModule : AbpModule
{

}

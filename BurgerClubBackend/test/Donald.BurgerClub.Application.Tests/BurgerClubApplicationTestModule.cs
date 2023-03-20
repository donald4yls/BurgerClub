using Volo.Abp.Modularity;

namespace Donald.BurgerClub;

[DependsOn(
    typeof(BurgerClubApplicationModule),
    typeof(BurgerClubDomainTestModule)
    )]
public class BurgerClubApplicationTestModule : AbpModule
{

}

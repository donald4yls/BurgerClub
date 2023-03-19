using Donald.BurgerClub.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Donald.BurgerClub;

[DependsOn(
    typeof(BurgerClubDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(BurgerClubApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class BurgerClubApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BurgerClubApplicationModule>();
        });

        Configure<AWSConfiguration>(configuration.GetSection("AWSConfiguration"));
    }
}

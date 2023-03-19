using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Donald.BurgerClub;

[Dependency(ReplaceServices = true)]
public class BurgerClubBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BurgerClub";
}

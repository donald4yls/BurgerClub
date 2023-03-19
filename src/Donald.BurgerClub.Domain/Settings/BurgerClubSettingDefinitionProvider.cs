using Volo.Abp.Settings;

namespace Donald.BurgerClub.Settings;

public class BurgerClubSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BurgerClubSettings.MySetting1));
    }
}

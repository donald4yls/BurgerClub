using Donald.BurgerClub.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Donald.BurgerClub.Permissions;

public class BurgerClubPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BurgerClubPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BurgerClubPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BurgerClubResource>(name);
    }
}

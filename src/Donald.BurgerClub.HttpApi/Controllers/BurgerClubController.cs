using Donald.BurgerClub.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Donald.BurgerClub.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BurgerClubController : AbpControllerBase
{
    protected BurgerClubController()
    {
        LocalizationResource = typeof(BurgerClubResource);
    }
}

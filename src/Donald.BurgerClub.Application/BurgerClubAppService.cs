using System;
using System.Collections.Generic;
using System.Text;
using Donald.BurgerClub.Localization;
using Volo.Abp.Application.Services;

namespace Donald.BurgerClub;

/* Inherit your application services from this class.
 */
public abstract class BurgerClubAppService : ApplicationService
{
    protected BurgerClubAppService()
    {
        LocalizationResource = typeof(BurgerClubResource);
    }
}

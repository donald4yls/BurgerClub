using Donald.BurgerClub.ViewModels;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Donald.BurgerClub.IServices
{
    public interface IBurgerClubUserService :
        ICrudAppService<BurgerClubUserDto,
                        Guid,
                        PagedAndSortedResultRequestDto,
                        BurgerClubUserCreateUpdateDto>
    {
    }
}

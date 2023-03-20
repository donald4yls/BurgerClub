using Donald.BurgerClub.ViewModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Donald.BurgerClub.IServices
{
    public interface IBurgerStoreService :
        ICrudAppService<BurgerStoreDto,
        int,
        PagedAndSortedResultRequestDto,
        BurgerStoreCreateUpdateDto>
    {
    }
}

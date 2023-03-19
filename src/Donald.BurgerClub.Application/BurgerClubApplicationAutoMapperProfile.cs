using AutoMapper;
using Donald.BurgerClub.Model;
using Donald.BurgerClub.ViewModels;

namespace Donald.BurgerClub;

public class BurgerClubApplicationAutoMapperProfile : Profile
{
    public BurgerClubApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BurgerStore, BurgerStoreDto>();
        CreateMap<BurgerStoreCreateUpdateDto, BurgerStore>();

        CreateMap<BurgerStoreMenu, BurgerStoreMenuDto>();
        CreateMap<BurgerStoreMenuCreateUpdateDto, BurgerStoreMenu>();

        CreateMap<BurgerClubUser, BurgerClubUserDto>();
        CreateMap<BurgerClubUserCreateUpdateDto, BurgerClubUser>();

        CreateMap<BurgerClubUserFan, BurgerClubUserFanDto>();
        CreateMap<BurgerClubUserFanCreateUpdateDto, BurgerClubUserFan>();
    }
}

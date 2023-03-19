using Donald.BurgerClub.Model;
using Donald.BurgerClub.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Donald.BurgerClub.Seeds
{
    public class BurgerStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<BurgerStore, int> _storeRepository;
        private readonly IRepository<BurgerStoreMenu, long> _storeMenuRepository;

        public BurgerStoreDataSeederContributor(IRepository<BurgerStore, int> storeRepository, IRepository<BurgerStoreMenu, long> storeMenuRepository)
        {
            _storeRepository = storeRepository;
            _storeMenuRepository = storeMenuRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await InsertInitialBurgerStore();
            await InsertInitialMenus();
        }

        public async Task InsertInitialBurgerStore()
        {
            if (await _storeRepository.GetCountAsync() <= 0)
            {
                await _storeRepository.InsertAsync(
                    new BurgerStore
                    {
                        Name = "BurgerKing",
                        Description = "No.1 Burger King Store",
                        MainPhoto = "https://creapills.com/wp-content/uploads/2021/01/burger-king-logo-2-1160x1160.png",
                        PositionLat = 31.22174,
                        PositionLon = 121.464688,
                        GeoHash = GeoHashHelper.ConvertToGeoHash(31.22174, 121.464688),
                        OpenningTime = "08:00 to 22:00",
                        AverageTextureScore = 4.3,
                        AverageTasteScore = 4.6,
                        AverageVisualPresentationScore = 4.2,
                    },
                    autoSave: true
                );

                await _storeRepository.InsertAsync(
                    new BurgerStore
                    {
                        Name = "MacDonald",
                        Description = "No.1 MacDonald Store",
                        MainPhoto = "https://chandigarhofficial.com/wp-content/uploads/2018/11/Mcdonals-Logo.png",
                        PositionLat = 31.229807,
                        PositionLon = 121.456377,
                        GeoHash = GeoHashHelper.ConvertToGeoHash(31.229807, 121.456377),
                        OpenningTime = "08:00 to 21:00",
                        AverageTextureScore = 4.5,
                        AverageTasteScore = 4.3,
                        AverageVisualPresentationScore = 4.8
                    },
                    autoSave: true
                );

                await _storeRepository.InsertAsync(
                    new BurgerStore
                    {
                        Name = "Kentucky Fried Chicken （KFC)",
                        Description = "No.1 Kentucky Fried Chicken Store",
                        MainPhoto = "https://1000logos.net/wp-content/uploads/2017/03/Kfc_logo.png",
                        PositionLat = 31.245234,
                        PositionLon = 121.503493,
                        GeoHash = GeoHashHelper.ConvertToGeoHash(31.245234, 121.503493),
                        OpenningTime = "08:00 to 23:00",
                        AverageTextureScore = 4.4,
                        AverageTasteScore = 4.5,
                        AverageVisualPresentationScore = 4.2
                    },
                    autoSave: true
                );
            }
        }

        public async Task InsertInitialMenus()
        {
            if(await _storeMenuRepository.GetCountAsync() <= 0)
            {
                await _storeMenuRepository.InsertAsync(
                    new BurgerStoreMenu
                    {
                        BurgerStoreId = 1,
                        MenuItemName = "Whopper",
                        MenuItemPhoto = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/238e287aa4d92d6e0cc4783e397b6e7386cd2e47-1333x1333.png",
                        MenuItemPrice = 40.0m
                    },
                    autoSave: true
                );

                await _storeMenuRepository.InsertAsync(
                    new BurgerStoreMenu
                    {
                        BurgerStoreId = 1,
                        MenuItemName = "Check Royle",
                        MenuItemPhoto = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/fc7c2a73e7a9bf14f3e3401bedcc090c4f421c67-1333x1333.png",
                        MenuItemPrice = 30.0m
                    },
                    autoSave: true
                );

                await _storeMenuRepository.InsertAsync(
                    new BurgerStoreMenu
                    {
                        BurgerStoreId = 1,
                        MenuItemName = "Bacon Double  Cheeseburger",
                        MenuItemPhoto = "https://cdn.sanity.io/images/czqk28jt/prod_bk_us/d06846598b47ff0ae865299a30b2826993567e9c-1333x1333.png",
                        MenuItemPrice = 35.0m
                    },
                    autoSave: true
                );

                await _storeMenuRepository.InsertAsync(
                    new BurgerStoreMenu
                    {
                        BurgerStoreId = 2,
                        MenuItemName = "Big Mac",
                        MenuItemPhoto = "https://s7d1.scene7.com/is/image/mcdonalds/DC_201907_0005_BigMac_832x472",
                        MenuItemPrice = 38.0m
                    },
                    autoSave: true
                );

                await _storeMenuRepository.InsertAsync(
                    new BurgerStoreMenu
                    {
                        BurgerStoreId = 3,
                        MenuItemName = "Extra Tasty Crispy Burger ",
                        MenuItemPhoto = "https://img14.360buyimg.com/pop/jfs/t1/119033/38/22938/102633/624d50afE56653fed/060112c5443d15e3.jpg",
                        MenuItemPrice = 30.0m
                    },
                    autoSave: true
                );
            }
        }
    }
}

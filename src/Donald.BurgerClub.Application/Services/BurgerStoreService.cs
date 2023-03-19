using Amazon.S3.Model;
using Donald.BurgerClub.IServices;
using Donald.BurgerClub.Model;
using Donald.BurgerClub.Utils;
using Donald.BurgerClub.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace Donald.BurgerClub.Services
{
    public class BurgerStoreService: 
        CrudAppService<BurgerStore, 
                        BurgerStoreDto,
                        int,
                        PagedAndSortedResultRequestDto,
                        BurgerStoreCreateUpdateDto>,
        IBurgerStoreService
    {

        private readonly IRepository<BurgerStoreMenu, long> _burgerStoreMenuRepository;

        public BurgerStoreService(IRepository<BurgerStore, int> burgerStoreRepository,
            IRepository<BurgerStoreMenu, long> burgerStoreMenuRepository)
            : base(burgerStoreRepository)
        {
            _burgerStoreMenuRepository = burgerStoreMenuRepository;
        }

        public async Task<List<BurgerStoreDto>> GetNearByBurgerStoresAsync(double positionLat, double postitionLon)
        {
            int geoHashMappingDistance = 6; //Distance within 1.2KM.

            var geoHash = GeoHashHelper.ConvertToGeoHash(positionLat, postitionLon);
            var geoHashWitnKm = geoHash.Length > geoHashMappingDistance ? geoHash.Substring(0, geoHashMappingDistance) : geoHash;

            var result = await Repository.GetListAsync(i => i.GeoHash.StartsWith(geoHashWitnKm)).ConfigureAwait(false);

            return ObjectMapper.Map<List<BurgerStore>, List<BurgerStoreDto>>(result);
        }

        public async Task<List<BurgerStoreMenuDto>> GetBurgerMenu(int burgerStoreId)
        {
            if(burgerStoreId < 0)
            {
                throw new AbpValidationException("Invalid Store Id");
            }

            var menus = await _burgerStoreMenuRepository.GetListAsync(i=>i.BurgerStoreId.Equals(burgerStoreId)).ConfigureAwait(false);

            return ObjectMapper.Map<List<BurgerStoreMenu>, List<BurgerStoreMenuDto>>(menus);
        }

        public async Task<BurgerStoreMenuDto> CreateBurgerMenu(BurgerStoreMenuCreateUpdateDto createDto)
        {
            if(createDto == null || createDto.BurgerStoreId < 0)
            {
                throw new AbpValidationException("Invalid BurgerStoreMenuCreateUpdateDto");
            }

            var count = await Repository.CountAsync(i=>i.Id.Equals(createDto.BurgerStoreId)).ConfigureAwait(false);

            if(count > 0)
            {
                var newMenu = ObjectMapper.Map<BurgerStoreMenuCreateUpdateDto, BurgerStoreMenu>(createDto);
                var result = await _burgerStoreMenuRepository.InsertAsync(newMenu, autoSave: true);

                return ObjectMapper.Map<BurgerStoreMenu, BurgerStoreMenuDto>(result);
            }
            else
            {
                throw new AbpValidationException("Invalid Store Id");
            }
        }
    }
}

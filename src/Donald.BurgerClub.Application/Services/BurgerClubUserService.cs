using Donald.BurgerClub.IServices;
using Donald.BurgerClub.Model;
using Donald.BurgerClub.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Donald.BurgerClub.Services
{
    public class BurgerClubUserService :
        CrudAppService<BurgerClubUser,
                        BurgerClubUserDto,
                        Guid,
                        PagedAndSortedResultRequestDto,
                        BurgerClubUserCreateUpdateDto>,
        IBurgerClubUserService
    {
        private readonly IRepository<BurgerClubUserFan, Guid> _fanRepository;

        public BurgerClubUserService(IRepository<BurgerClubUser, Guid> repository, IRepository<BurgerClubUserFan, Guid> fanRepository) 
            : base(repository)
        {
            _fanRepository = fanRepository;
        }

        /// <summary>
        /// GetFans
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageSize">Default value 10</param>
        /// <param name="pageIndex">Default value 0</param>
        /// <returns></returns>
        public async Task<List<BurgerClubUserFanDto>> GetFans(Guid userId, int pageSize = 10, int pageIndex = 0)
        {
            var queryable = await _fanRepository.GetQueryableAsync();
            var query = queryable.Where(i => i.UserId.Equals(userId))
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize);

            var fans = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<BurgerClubUserFan>, List<BurgerClubUserFanDto>>(fans);
        }

        public async Task<BurgerClubUserFanDto> AddFans(BurgerClubUserFanCreateUpdateDto fan)
        {
            if(fan == null)
            {
                throw new ArgumentNullException(nameof(fan));
            }

            var userIds = new List<Guid>() { fan.UserId, fan.FanId };
            var clubUsersCount = await Repository.CountAsync(i => userIds.Contains(i.Id)).ConfigureAwait(false);

            if(clubUsersCount == 2)
            {
                var fanEntity = ObjectMapper.Map<BurgerClubUserFanCreateUpdateDto, BurgerClubUserFan>(fan);
                var result = await _fanRepository.InsertAsync(fanEntity, autoSave: true).ConfigureAwait(false);

                return ObjectMapper.Map<BurgerClubUserFan, BurgerClubUserFanDto>(result);
            }
            else
            {
                throw new BusinessException("Can't find user.");
            }
        }


    }

}

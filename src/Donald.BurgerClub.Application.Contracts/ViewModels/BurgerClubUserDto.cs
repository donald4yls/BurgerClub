using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Donald.BurgerClub.ViewModels
{
    public class BurgerClubUserDto: EntityDto<Guid>
    {
        public string ClubUserName { get; set; }

        public string ShortDescription { get; set; }

        public DateTime CreateTime { get; set; } 

        public DateTime UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class BurgerClubUserCreateUpdateDto
    {
        public string ClubUserName { get; set; }

        public string Password { get; set; }

        public string ShortDescription { get; set; }

        public DateTime CreateTime { get; set; }
    }

    public class BurgerClubUserFanDto: EntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid FanId { get; set; }

        public DateTime FollwTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class BurgerClubUserFanCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public Guid FanId { get; set; }
    }
}

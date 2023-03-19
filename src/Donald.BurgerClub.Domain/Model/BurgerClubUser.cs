using System;
using Volo.Abp.Domain.Entities;

namespace Donald.BurgerClub.Model
{
    public class BurgerClubUser : Entity<Guid>
    {
        public string ClubUserName { get; set; }

        public string Password { get; set; }

        public string ShortDescription { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class BurgerClubUserActive : Entity<Guid>
    {
        public Guid BurgerClubUserId { get; set; }

        public string Note { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class BurgerClubUserActivePhoto : Entity<Guid>
    {
        public Guid BurgerClubUserActiveId { get; set; }

        public string Photo { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class BurgerClubUserFan : Entity<Guid>
    {
        public Guid UserId { get; set; }

        public Guid FanId { get; set; }

        public DateTime FollwTime { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime DeleteTime { get; set; }

        public bool IsDeleted { get; set; }
    }

}

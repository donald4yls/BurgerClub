using System;
using Volo.Abp.Application.Dtos;

namespace Donald.BurgerClub.ViewModels
{
    public class BurgerStoreScoreDto : EntityDto<Guid>
    {
        public int BurgerStoreId { get; set; }

        public Guid BurgerClubUserId { get; set; }

        /// <summary>
        /// Score value between 0-10;
        /// 0 is the lowest, 10 is the highest
        /// </summary>
        public int TasteScore { get; set; }

        /// <summary>
        /// Score value between 0-10;
        /// 0 is the lowest, 10 is the highest
        /// </summary>
        public int TextureScore { get; set; }

        /// <summary>
        /// Score value between 0-10;
        /// 0 is the lowest, 10 is the highest
        /// </summary>
        public int VisualPresentationScore { get; set; }
    }
}

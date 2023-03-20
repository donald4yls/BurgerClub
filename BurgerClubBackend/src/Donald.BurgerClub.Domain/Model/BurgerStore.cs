using System;
using Volo.Abp.Domain.Entities;

namespace Donald.BurgerClub.Model
{
    public class BurgerStore: Entity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MainPhoto { get; set; }

        public double PositionLat { get; set; } 

        public double PositionLon { get; set; }

        public string GeoHash { get; set; }

        public string OpenningTime { get; set; }

        /// <summary>
        /// Score value between 0-10;
        /// 0 is the lowest, 10 is the highest
        /// </summary>
        public double AverageTasteScore { get; set; }

        /// <summary>
        /// Score value between 0-10;
        /// 0 is the lowest, 10 is the highest
        /// </summary>
        public double AverageTextureScore { get; set; }

        /// <summary>
        /// Score value between 0-10;
        /// 0 is the lowest, 10 is the highest
        /// </summary>
        public double AverageVisualPresentationScore { get; set; }
    }

    public class BurgerStoreScore: Entity<Guid>
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

    public class BurgerStoreMenu: Entity<long>
    {
        public int BurgerStoreId { get; set; }

        public string MenuItemName { get; set; }

        public string MenuItemPhoto { get; set; }

        public decimal MenuItemPrice { get; set; }
    }
}

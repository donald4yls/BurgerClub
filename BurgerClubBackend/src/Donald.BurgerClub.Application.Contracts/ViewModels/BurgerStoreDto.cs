using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Donald.BurgerClub.ViewModels
{
    public class BurgerStoreDto: EntityDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MainPhoto { get; set; }

        public double PositionLat { get; set; }

        public double PositionLon { get; set; }

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

    public class BurgerStoreCreateUpdateDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        public string MainPhoto { get; set; }

        [Required]
        public double PositionLat { get; set; }

        [Required]
        public double PositionLon { get; set; }

        [Required]
        public string OpenningTime { get; set; }
    }
}

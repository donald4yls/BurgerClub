using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Donald.BurgerClub.ViewModels
{
    public class BurgerStoreMenuDto : EntityDto<long>
    {
        public int BurgerStoreId { get; set; }

        public string MenuItemName { get; set; }

        public string MenuItemPhoto { get; set; }

        public decimal MenuItemPrice { get; set; }
    }

    public class BurgerStoreMenuCreateUpdateDto
    {
        [Required]
        public int BurgerStoreId { get; set; }

        [Required]
        [StringLength(128)]
        public string MenuItemName { get; set; }

        [Required]
        public string MenuItemPhoto { get; set; }

        public decimal MenuItemPrice { get; set; }
    }
}

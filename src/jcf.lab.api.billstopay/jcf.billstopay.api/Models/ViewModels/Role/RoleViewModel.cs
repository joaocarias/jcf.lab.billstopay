using jcf.billstopay.api.Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models.ViewModels.Role
{
    public class RoleViewModel : EntityBaseViewModel
    {
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}

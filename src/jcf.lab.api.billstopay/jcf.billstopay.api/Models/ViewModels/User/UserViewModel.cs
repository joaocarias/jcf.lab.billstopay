using jcf.billstopay.api.Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models.ViewModels.User
{
    public class UserViewModel : EntityBaseViewModel
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }               
    }
}

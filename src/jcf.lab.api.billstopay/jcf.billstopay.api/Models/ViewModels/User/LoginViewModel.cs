using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models.ViewModels.User
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

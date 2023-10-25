using jcf.billstopay.api.Models.ViewModel;

namespace jcf.billstopay.api.Models.ViewModels.Role
{
    public class RoleUserViewModel : EntityBaseViewModel
    {
        public Guid UserId { get; set; }       
        public Guid RoleId { get; set; }
       
    }
}

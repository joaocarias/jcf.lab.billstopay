using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models
{
    public class Role : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string RoleName { get; private set; }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public void Update(string roleName)
        {            
            RoleName = roleName;
            Updated();
        }
    }
}

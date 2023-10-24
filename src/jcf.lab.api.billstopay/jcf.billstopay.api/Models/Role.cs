using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models
{
    public class Role(string roleName) : EntityBase()
    {
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } = roleName;
    }
}

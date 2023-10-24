using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(200)]
        public string Name { get; private set; }

        [Required]
        [StringLength(200)] 
        public string Email { get; private set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; private set; }

        [Required]
        [StringLength(200)]
        public string Password { get; private set; }        

        public IEnumerable<Role> Roles { get; private set; }

        public User(string name, string email, string? userName, string password ) : base()
        {
            Name = name;
            Email = email;
            UserName = string.IsNullOrEmpty(userName) ? email : userName;
            Password = password;
            Roles = new List<Role>();
        }

        public void SetRoles(IEnumerable<Role> roles)
        {
            Roles = roles;
        }


    }
}

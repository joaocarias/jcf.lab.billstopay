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

        public IEnumerable<RoleUser> RolesUser { get; set; }

        public User(string name, string email, string? userName, string password ) : base()
        {
            Name = name;
            Email = email;
            UserName = string.IsNullOrEmpty(userName) ? email : userName;
            Password = password;
            RolesUser = new List<RoleUser>();
        }

        public void AddRoles(Role role)
        {
            try
            {
                RolesUser ??= new List<RoleUser>();
                RolesUser.ToList().Add(new (role));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public void Update(string name, string email, string? userName)
        {
            Name = name;
            Email = email;
            UserName = string.IsNullOrEmpty(userName) ? email : userName;
            Updated();
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}

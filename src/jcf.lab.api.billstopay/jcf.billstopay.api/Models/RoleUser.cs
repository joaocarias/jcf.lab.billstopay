namespace jcf.billstopay.api.Models
{
    public class RoleUser : EntityBase
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }
    }
}

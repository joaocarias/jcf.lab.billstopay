namespace jcf.billstopay.api.Models.ViewModel
{
    public class EntityBaseViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace jcf.billstopay.api.Models
{
    public abstract class EntityBase
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public DateTime CreateAt { get; private set; } = DateTime.Now;
        public DateTime? UpdateAt { get; private set; }
        public bool IsActive { get; private set; } = true;
    }
}

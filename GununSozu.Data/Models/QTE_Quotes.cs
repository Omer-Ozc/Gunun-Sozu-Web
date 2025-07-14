using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GununSozu.Data.Models
{
    public class QTE_Quotes
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Content { get; set; }
        public string Author { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(Language))]
        public Guid LanguageId { get; set; }

        public bool IsActive { get; set; }

        // Navigation
        public virtual QTE_Categories Category { get; set; }
        public virtual SYS_Language Language { get; set; }

        public virtual ICollection<USR_Favorites> Favorites { get; set; }
        public virtual ICollection<USR_Deliveries> Deliveries { get; set; }
    }
}

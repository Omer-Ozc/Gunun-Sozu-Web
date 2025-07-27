using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GununSozu.Data.Models
{
    public class USR_Favorites
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Quote))]
        public Guid QuoteId { get; set; }

        public bool? IsLiked { get; set; }
        // Navigation
        public virtual USR_Users User { get; set; }
        public virtual QTE_Quotes Quote { get; set; }
    }
}

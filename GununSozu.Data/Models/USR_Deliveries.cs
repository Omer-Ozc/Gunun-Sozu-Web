using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GununSozu.Data.Models
{
    public class USR_Deliveries
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Quote))]
        public Guid QuoteId { get; set; }

        public DateTime SentAt { get; set; }
        public bool WasOpened { get; set; }
        public bool WasLiked { get; set; }

        // Navigation
        public virtual USR_Users User { get; set; }
        public virtual QTE_Quotes Quote { get; set; }
    }
}

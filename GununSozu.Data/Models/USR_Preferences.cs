using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GununSozu.Data.Models
{
    public class USR_Preferences
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public string NotificationTime1 { get; set; }
        public string NotificationTime2 { get; set; }
        public int NotificationFreq { get; set; }
        public int PreferredCategory { get; set; }

        // Navigation
        public virtual USR_Users User { get; set; }
    }
}

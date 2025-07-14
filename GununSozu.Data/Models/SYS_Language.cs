using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GununSozu.Data.Models
{
    public class SYS_Language
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        // Navigation
        public virtual ICollection<QTE_Quotes> Quotes { get; set; }
    }
}

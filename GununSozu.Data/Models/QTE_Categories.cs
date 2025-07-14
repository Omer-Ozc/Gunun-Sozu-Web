using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GununSozu.Data.Models
{
    public class QTE_Categories
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation
        public virtual ICollection<QTE_Quotes> Quotes { get; set; }
    }
}

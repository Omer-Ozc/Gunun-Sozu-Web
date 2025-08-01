using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GununSozu.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; } = Guid.NewGuid();
        public string DeviceId { get; set; }

        [ForeignKey(nameof(Language))]
        public Guid LanguageId { get; set; }

        // Navigation
        public virtual ICollection<USR_Preferences> Preferences { get; set; }
        public virtual ICollection<USR_Favorites> Favorites { get; set; }
        public virtual ICollection<USR_Deliveries> Deliveries { get; set; }
        public virtual SYS_Language Language { get; set; }
    }
}

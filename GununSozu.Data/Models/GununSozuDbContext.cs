using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GununSozu.Data.Models;

public partial class GununSozuDbContext : IdentityDbContext<IdentityUser>
{
    public GununSozuDbContext(DbContextOptions<GununSozuDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<QTE_Quotes> QTE_Quotes { get; set; }
    public virtual DbSet<QTE_Categories> QTE_Categories { get; set; }
    public virtual DbSet<SYS_Language> SYS_Language { get; set; }

    public virtual DbSet<USR_Users> USR_Users { get; set; }
    public virtual DbSet<USR_Preferences> USR_Preferences { get; set; }
    public virtual DbSet<USR_Favorites> USR_Favorites { get; set; }
    public virtual DbSet<USR_Deliveries> USR_Deliveries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<QTE_Quotes>().ToTable("QTE_Quotes");
        modelBuilder.Entity<QTE_Categories>().ToTable("QTE_Categories");
        modelBuilder.Entity<SYS_Language>().ToTable("SYS_Language");

        modelBuilder.Entity<USR_Users>().ToTable("USR_Users");
        modelBuilder.Entity<USR_Preferences>().ToTable("USR_Preferences");

        modelBuilder.Entity<USR_Favorites>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<USR_Favorites>()
            .HasOne(f => f.Quote)
            .WithMany(q => q.Favorites)
            .HasForeignKey(f => f.QuoteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<USR_Deliveries>()
            .HasOne(d => d.User)
            .WithMany(u => u.Deliveries)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<USR_Deliveries>()
            .HasOne(d => d.Quote)
            .WithMany(q => q.Deliveries)
            .HasForeignKey(d => d.QuoteId)
            .OnDelete(DeleteBehavior.Restrict);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


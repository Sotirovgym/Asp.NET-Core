namespace Panda.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Panda.Models.Entities;

    public class PandaDbContext : IdentityDbContext<MyIdentityUser>
    {
        public DbSet<MyIdentityUser> ApplicationUsers { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext() {}

        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Receipt>()
                .HasOne(r => r.Package)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.PackageId);

            builder.Entity<MyIdentityUser>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(r => r.RecipientId);

            builder.Entity<MyIdentityUser>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(p => p.RecipientId);
        }
    }
}

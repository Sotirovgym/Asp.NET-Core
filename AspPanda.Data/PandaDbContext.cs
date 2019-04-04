namespace AspPanda.Data
{
    using AspPanda.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext()
        {

        }

        public PandaDbContext(DbContextOptions optionsBuilder)
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Panda;Integrated Security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Receipt>()
                .HasOne(r => r.Package)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.PackageId);

            builder.Entity<User>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(r => r.RecipientId);

            builder.Entity<User>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(p => p.RecipientId);
        }
    }
}

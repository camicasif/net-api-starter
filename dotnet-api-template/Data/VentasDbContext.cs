using Microsoft.EntityFrameworkCore;
namespace dotnet_api_template.Data
{

    public class VentasDbContext : DbContext
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is AuditableEntity &&
                           (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (AuditableEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.Deleted = false;
                }

                entity.ModifiedDate = DateTime.UtcNow;
                entity.ModifiedBy = "system";
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Dni)
                .IsUnique(); // DNI único

            base.OnModelCreating(modelBuilder);
        }
    }

}
using Microsoft.EntityFrameworkCore;

namespace SmartMed.Infrastructure.Medication
{
    public class MedicationContext
    {
        public static void SetModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Medication>().ToTable("Medications");
            modelBuilder.Entity<Model.Medication>().HasKey(s => s.Id);
            modelBuilder.Entity<Model.Medication>().Ignore(c => c.Errors);
            modelBuilder.Entity<Model.Medication>(entity =>
            {
                entity.Property(o => o.Name).IsRequired().HasMaxLength(30);
                entity.Property(o => o.Quantity).IsRequired();
                entity.Property(o => o.CreationDate).IsRequired();
                entity.Property(o => o.Id).IsRequired();
                entity.Property(o => o.UniqueId).IsRequired();

                entity.HasIndex(u => u.UniqueId).IsUnique();
            });         
        }
    }
}

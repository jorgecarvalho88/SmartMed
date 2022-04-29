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

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Medication>().HasData(
                new Model.Medication("Ibuprofeno", 3),
                new Model.Medication("Paracetemol", 5),
                new Model.Medication("Aspirina", 2),
                new Model.Medication("Tramadol", 1),
                new Model.Medication("Codeína", 10),
                new Model.Medication("Metamizol", 5),
                new Model.Medication("Gabapentina", 4),
                new Model.Medication("Daflon", 20)
                );
        }
    }
}

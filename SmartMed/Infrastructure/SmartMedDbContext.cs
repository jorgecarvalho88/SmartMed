using Microsoft.EntityFrameworkCore;
using SmartMed.Infrastructure.Medication;

namespace SmartMed.Infrastructure
{
    public class SmartMedDbContext : DbContext
    {
        public SmartMedDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Model.Medication> Medications => Set<Model.Medication>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MedicationContext.SetModel(modelBuilder);
        }
    }
}

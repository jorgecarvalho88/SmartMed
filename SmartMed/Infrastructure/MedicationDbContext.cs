using Microsoft.EntityFrameworkCore;
using SmartMed.Infrastructure.Medication;

namespace SmartMed.Infrastructure
{
    public class MedicationDbContext : DbContext
    {
        public MedicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Model.Medication> Medications => Set<Model.Medication>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MedicationContext.SetModel(modelBuilder);
        }
    }
}

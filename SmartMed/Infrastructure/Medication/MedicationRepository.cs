using DataExtension;
using Microsoft.EntityFrameworkCore;

namespace SmartMed.Infrastructure.Medication
{
    public class MedicationRepository : RepositoryBase, IMedicationRepository
    {
        public MedicationRepository(SmartMedDbContext context) : base(context)
        {

        }

        public IQueryable<Model.Medication> Get()
        {
            return base.GetQueryable<Model.Medication>();
        }

        public async Task<Model.Medication?> Get(Guid uniqueId)
        {
            return await Get().Where(m => m.UniqueId == uniqueId).FirstOrDefaultAsync();
        }

        public async Task<List<Model.Medication>> GetAll()
        {
            return await Get().ToListAsync();
        }
    }
}

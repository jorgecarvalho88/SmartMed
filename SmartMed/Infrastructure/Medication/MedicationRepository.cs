using DataExtension;

namespace SmartMed.Infrastructure.Medication
{
    public class MedicationRepository : RepositoryBase, IMedicationRepository
    {
        public MedicationRepository(MedicationDbContext context) : base(context)
        {

        }

        public IQueryable<Model.Medication> Get()
        {
            return base.GetQueryable<Model.Medication>();
        }

        public Model.Medication Get(Guid uniqueId)
        {
            return Get().Where(m => m.UniqueId == uniqueId).FirstOrDefault();
        }

        public List<Model.Medication> GetAll()
        {
            return Get().ToList();
        }
    }
}

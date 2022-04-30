using DataExtension;

namespace SmartMed.Infrastructure.Medication
{
    public interface IMedicationRepository : IRepositoryBase
    {
        Task<Model.Medication?> Get(Guid uniqueId);
        Task<List<Model.Medication>> GetAll();
    }
}

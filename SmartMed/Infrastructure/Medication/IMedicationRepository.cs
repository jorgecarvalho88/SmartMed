using DataExtension;

namespace SmartMed.Infrastructure.Medication
{
    public interface IMedicationRepository : IRepositoryBase
    {
        Model.Medication Get(Guid uniqueId);
        List<Model.Medication> GetAll();
    }
}

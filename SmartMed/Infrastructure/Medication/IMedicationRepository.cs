using DataExtension;

namespace SmartMed.Infrastructure.Medication
{
    public interface IMedicationRepository : IRepositoryBase
    {
        Model.Medication Get(string name);
        List<Model.Medication> GetAll();
    }
}

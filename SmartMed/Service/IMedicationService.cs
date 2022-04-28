using SmartMed.Dtos;

namespace SmartMed.Service
{
    public interface IMedicationService
    {
        List<MedicationDto> GetAll();
        MedicationDto Add(MedicationDto user);
        MedicationDto Delete(Guid uniqueId);
    }
}

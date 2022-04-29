using SmartMed.Dtos;

namespace SmartMed.Service
{
    public interface IMedicationService
    {
        List<MedicationResponseDto> GetAll();
        MedicationResponseDto Add(MedicationRequestDto user);
        MedicationResponseDto Delete(Guid uniqueId);
    }
}

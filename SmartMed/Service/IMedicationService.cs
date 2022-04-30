using SmartMed.Dtos;

namespace SmartMed.Service
{
    public interface IMedicationService
    {
        Task<List<MedicationResponseDto>> GetAll();
        Task<MedicationResponseDto> Add(MedicationRequestDto user);
        Task<MedicationResponseDto> Delete(Guid uniqueId);
    }
}

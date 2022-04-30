using AutoMapper;
using SmartMed.Dtos;
using SmartMed.Infrastructure.Medication;
using SmartMed.Model;

namespace SmartMed.Service
{
    public class MedicationService : IMedicationService
    {
        private IMedicationRepository _medicationRepository;
        private readonly IMapper _maper;
        public MedicationService(IMedicationRepository medicationRepository, IMapper maper)
        {
            _medicationRepository = medicationRepository;
            _maper = maper;
        }

        public async Task<List<MedicationResponseDto>> GetAll()
        {
            return _maper.Map<List<Medication> ,List<MedicationResponseDto>>(await _medicationRepository.GetAll());
        }

        public async Task<MedicationResponseDto> Add(MedicationRequestDto medication)
        {
            await _medicationRepository.BeginTransaction();

            var newMedication = new Medication(medication.Name, medication.Quantity);

            if (newMedication.IsValid)
            {
                _medicationRepository.Create(newMedication);
                await _medicationRepository.Commit();
                await _medicationRepository.CommitTransaction();
            }
            else
            {
                await _medicationRepository.RollBackTransaction();
            }

            return _maper.Map<MedicationResponseDto>(newMedication);
        }

        public async Task<MedicationResponseDto> Delete(Guid medicationId)
        {
            await _medicationRepository.BeginTransaction();

            var existingMedication = await _medicationRepository.Get(medicationId);
            if (existingMedication is null)
            {
                await _medicationRepository.RollBackTransaction();
                return new MedicationResponseDto() { Errors = new List<string>() { "Invalid UniqueId" } };
            }

            var medicationDto = _maper.Map<MedicationResponseDto>(existingMedication);

            _medicationRepository.Delete(existingMedication);
            await _medicationRepository.Commit();
            await _medicationRepository.CommitTransaction();

            return medicationDto;
        }
    }
}

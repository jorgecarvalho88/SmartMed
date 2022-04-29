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

        public List<MedicationResponseDto> GetAll()
        {
            return _maper.Map<List<Medication> ,List<MedicationResponseDto>>(_medicationRepository.GetAll());
        }

        public MedicationResponseDto Add(MedicationRequestDto medication)
        {
            _medicationRepository.BeginTransaction();

            var newMedication = new Medication(medication.Name, medication.Quantity);

            if (newMedication.IsValid)
            {
                _medicationRepository.Create(newMedication);
                _medicationRepository.Commit();
                _medicationRepository.CommitTransaction();
            }
            else
            {
                _medicationRepository.RollBackTransaction();
            }

            return _maper.Map<MedicationResponseDto>(newMedication);
        }

        public MedicationResponseDto Delete(Guid medicationId)
        {
            _medicationRepository.BeginTransaction();

            var existingMedication = _medicationRepository.Get(medicationId);
            if (existingMedication is null)
            {
                _medicationRepository.RollBackTransaction();
                return new MedicationResponseDto() { Errors = new List<string>() { "Invalid UniqueId" } };
            }

            var medicationDto = _maper.Map<MedicationResponseDto>(existingMedication);

            _medicationRepository.Delete(existingMedication);
            _medicationRepository.Commit();
            _medicationRepository.CommitTransaction();
            return medicationDto;
        }
    }
}

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

        public List<MedicationDto> GetAll()
        {
            return _maper.Map<List<Medication> ,List<MedicationDto>>(_medicationRepository.GetAll());
        }

        public MedicationDto Add(MedicationDto medication)
        {
            _medicationRepository.BeginTransaction();

            var newMedication = new Medication(medication.Name, medication.Quantity);

            if (medication.IsValid)
            {
                _medicationRepository.Create(newMedication);
                _medicationRepository.Commit();
                _medicationRepository.CommitTransaction();

                medication.UniqueId = newMedication.UniqueId;
            }
            else
            {
                _medicationRepository.RollBackTransaction();
                medication.Errors.AddRange(newMedication.Errors);
            }

            return medication;
        }

        public MedicationDto Delete(Guid medicationId)
        {
            _medicationRepository.BeginTransaction();

            var existingMedication = _medicationRepository.Get(medicationId);
            if (existingMedication is null)
            {
                _medicationRepository.RollBackTransaction();
                return new MedicationDto()
                {
                    Errors = new List<string>() { "Invalid UniqueId" }
                };
            }

            var medicationDto = _maper.Map<MedicationDto>(existingMedication);

            _medicationRepository.Delete(existingMedication);
            _medicationRepository.Commit();
            _medicationRepository.CommitTransaction();
            return medicationDto;
        }
    }
}

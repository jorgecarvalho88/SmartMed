using SmartMed.Dtos;
using SmartMed.Infrastructure.Medication;
using SmartMed.Model;

namespace SmartMed.Service
{
    public class MedicationService : IMedicationService
    {
        private IMedicationRepository _medicationRepository;
        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public List<MedicationDto> GetAll()
        {
            throw new NotImplementedException();
            //return ConvertToDto(_medicationRepository.GetAll());
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
        }
    }
    #region Methods
    //private List<MedicationDto> ConvertToDto(List<Medication> medications)
    //{

    //}
    #endregion
}

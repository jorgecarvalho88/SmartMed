using Validations;

namespace SmartMed.Dtos
{
    public class MedicationResponseDto : ValidationBase
    {
        public MedicationResponseDto()
        {}

        public MedicationResponseDto(Guid uniqueId, string name, int quantity, DateTime creationDate)
        {
            UniqueId = uniqueId;
            Name = name;
            Quantity = quantity;
            CreationDate = creationDate;

        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

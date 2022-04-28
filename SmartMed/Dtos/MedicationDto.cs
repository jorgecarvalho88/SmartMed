using Validations;

namespace SmartMed.Dtos
{
    public class MedicationDto : ValidationBase
    {
        public MedicationDto()
        {}

        public MedicationDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

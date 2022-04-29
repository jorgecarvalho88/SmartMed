namespace SmartMed.Dtos
{
    public class MedicationRequestDto
    {
        public MedicationRequestDto()
        {

        }

        public MedicationRequestDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

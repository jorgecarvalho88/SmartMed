using DataExtension;
using Validations;

namespace SmartMed.Model
{
    public class Medication : BaseEntity
    {
        public Medication()
        { }

        public Medication(string name, int quantity)
        {
            SetName(name);
            SetQuantity(quantity);
        }

        public string Name { get; protected set; }
        public int Quantity { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        #region Métodos

        public void SetName(string name)
        {
            ValidateIsNullOrWhiteSpace(name, "Name");
            Name = name;
        }

        public void SetQuantity(int quantity)
        {
            ValidateQuantity(quantity);
            Quantity = quantity;
        }

        private void ValidateIsNullOrWhiteSpace(string value, string property)
        {
            var error = StringValidator.ValidateIsNullOrWhiteSpace(value, property);
            if (error != null) this.Errors.Add(error);
        }

        private void ValidateQuantity(int quantity)
        {
            if (quantity <= 0) this.Errors.Add("Quantity must by greater than 0");
        }
        #endregion
    }
}

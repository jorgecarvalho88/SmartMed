using SmartMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartApiUT
{
    public class MedicationModelTests
    {
        [Fact]
        public void Medication_Quantity_ValidateGreaterThanZero_Sucess()
        {
            var medicationName = "Vigatnol";
            var quantity = 4;

            var medication = new Medication(medicationName, quantity);

            Assert.True(medication.IsValid);
        }

        [Theory]
        [InlineData("Montelucaste", 0, "Quantity must by greater than 0")]
        [InlineData("Vigantol", -5, "Quantity must by greater than 0")]
        public void Medication_Quantity_ValidateGreaterThanZero_Fail(string name, int quantity, string expectedError)
        {
            var medication = new Medication(name, quantity);

            Assert.False(medication.IsValid);
            Assert.Equal(expectedError, medication.Errors.First());
        }
    }
}

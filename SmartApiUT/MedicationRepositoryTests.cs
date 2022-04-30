using Microsoft.EntityFrameworkCore;
using SmartMed.Infrastructure;
using SmartMed.Infrastructure.Medication;
using SmartMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmartApiUT
{
    public class MedicationRepositoryTests
    {
        private readonly SmartMedDbContext context;
        private Medication invalidMedication = new Medication("Vigantol", 0);
        private List<Medication> medicationList = new List<Medication>()
        {
            new Medication("Montelucaste", 5),
            new Medication("Vigantol", 2)
        };
        public MedicationRepositoryTests()
        {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder().UseInMemoryDatabase(
                Guid.NewGuid().ToString());

            context = new SmartMedDbContext(dbOptions.Options);
        }

        [Fact]
        public async void GetAll_Sucess()
        {
            context.AddRange(medicationList);
            await context.SaveChangesAsync();
            var medicationRepository = new MedicationRepository(context);

            var result = await medicationRepository.GetAll();

            Assert.Equal(medicationList.GetType(), result.GetType());
            Assert.Equal(medicationList.Count, result.Count);
        }

        [Fact]
        public void CreateMedication_Sucess()
        {
            var medicationRepository = new MedicationRepository(context);

            var result = medicationRepository.Create(medicationList.First());

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.Equal(medicationList.First().Name, result.Name);
        }

        [Fact]
        public void CreateMedication_WithQuantityLessThanZero_Fail()
        {
            var medicationRepository = new MedicationRepository(context);

            var result = medicationRepository.Create(invalidMedication);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Quantity must by greater than 0", result.Errors.First());
            Assert.NotEqual(0, result.Id);
        }

        [Fact]
        public async void DeleteMedication_Sucess()
        {
            var medicationRepository = new MedicationRepository(context);
            var newMedication = medicationRepository.Create(medicationList.First());
            await medicationRepository.Commit();

            medicationRepository.Delete(newMedication);
            var changes = await medicationRepository.Commit();

            Assert.Equal(1, changes);
        }

        [Fact]
        public async void DeleteMedication_InvalidMedication_Fail()
        {
            var medicationRepository = new MedicationRepository(context);

            medicationRepository.Delete(medicationList.First());

            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await medicationRepository.Commit());
        }
    }
}
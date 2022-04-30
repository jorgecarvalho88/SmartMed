using AutoMapper;
using Moq;
using SmartMed.Dtos;
using SmartMed.Infrastructure.Medication;
using SmartMed.Model;
using SmartMed.Profiles;
using SmartMed.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SmartApiUT
{
    public class MedicationServiceTests
    {
        private readonly Mock<IMedicationRepository> _medicationRepository;
        private IMapper _maper = new Mapper(new MapperConfiguration(c => c.AddMaps(AppDomain.CurrentDomain.GetAssemblies())));
        private List<Medication> medicationList = new List<Medication>()
        {
            new Medication("Montelucaste", 5),
            new Medication("Vigantol", 2)
        };
        private MedicationRequestDto medicationDto = new MedicationRequestDto("Vigantol", 2);
        private MedicationRequestDto invalidMedicationDto = new MedicationRequestDto("Vigantol", 0);

        public MedicationServiceTests()
        {
            _medicationRepository = new Mock<IMedicationRepository>();
        }

        [Fact]
        public async void GetAllMedications_Success()
        {
            _medicationRepository.Setup(s => s.GetAll()).Returns(Task.FromResult(medicationList));

            var medicationService = new MedicationService(_medicationRepository.Object, _maper);
            var result = await medicationService.GetAll();

            Assert.Equal(medicationList.Count, result.Count);
        }

        [Fact]
        public async void AddMedication_Success()
        {
            _medicationRepository.Setup(s => s.Create(It.IsAny<Medication>())).Returns(medicationList.First());

            var medicationService = new MedicationService(_medicationRepository.Object, _maper);
            var result = await medicationService.Add(medicationDto);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.Equal(medicationDto.Name, result.Name);
        }

        [Fact]
        public async void AddMedication_WithInvalidQuantity_Fail()
        {
            _medicationRepository.Setup(s => s.Create(It.IsAny<Medication>())).Returns(medicationList.First());

            var medicationService = new MedicationService(_medicationRepository.Object, _maper);
            var result = await medicationService.Add(invalidMedicationDto);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Quantity must by greater than 0", result.Errors.First());
        }

        [Fact]
        public async void DeleteMedication_Success()
        {
            _medicationRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(Task.FromResult(medicationList?.First()));
            _medicationRepository.Setup(s => s.Delete(It.IsAny<Medication>()));

            var medicationService = new MedicationService(_medicationRepository.Object, _maper);
            var result = await medicationService.Delete(medicationList.First().UniqueId);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.Equal(medicationList.First().UniqueId, result.UniqueId);
        }

        [Fact]
        public async void DeleteMedication_WithInvalidUniqueId_Fail()
        {
            _medicationRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(Task.FromResult((Medication?)null));

            var medicationService = new MedicationService(_medicationRepository.Object, _maper);
            var result = await medicationService.Delete(Guid.NewGuid());

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Invalid UniqueId", result.Errors.First());
        }
    }
}

using ApiExtension;
using Microsoft.AspNetCore.Mvc;
using SmartMed.Dtos;
using SmartMed.Service;

namespace SmartMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationsController : ApiControllerBase
    {
        private IMedicationService _medicationService;
        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok(_medicationService.GetAll());
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add(MedicationDto medication)
        {
            return Ok(_medicationService.Add(medication));
        }

        [HttpDelete]
        [Route("{uniqueId}")]
        public IActionResult Delete(Guid uniqueId)
        {
            return Ok(_medicationService.Delete(uniqueId));
        }
    }
}

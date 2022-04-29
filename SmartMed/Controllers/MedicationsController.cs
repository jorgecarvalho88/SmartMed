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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IEnumerable<MedicationResponseDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            return Ok(_medicationService.GetAll());
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MedicationResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<MedicationResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add(MedicationRequestDto medication)
        {
            return Ok(_medicationService.Add(medication));
        }

        [HttpDelete]
        [Route("{uniqueId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MedicationResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<MedicationResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid uniqueId)
        {
            return Ok(_medicationService.Delete(uniqueId));
        }
    }
}

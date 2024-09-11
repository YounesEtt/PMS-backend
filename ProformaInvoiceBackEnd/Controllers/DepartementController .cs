using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly DepartementService _departementService;

        public DepartementController(DepartementService departementService)
        {
            _departementService = departementService;
        }

        [HttpGet("GetAllDepartement")]
        public IActionResult GetAllDepartements()
        {
            var departements = _departementService.GetAllDepartements();
            return Ok(departements);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartementById(int id)
        {
            var departement = _departementService.GetDepartementById(id);
            if (departement == null)
            {
                return NotFound();
            }
            return Ok(departement);
        }

        [HttpPost]
        public IActionResult CreateDepartement([FromBody] Departement departement)
        {
            var createdDepartement = _departementService.CreateDepartement(departement);
            return CreatedAtAction(nameof(GetDepartementById), new { id = createdDepartement.Id_departement }, createdDepartement);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartement(int id, [FromBody] Departement departement)
        {
            _departementService.UpdateDepartement(id, departement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartement(int id)
        {
            _departementService.DeleteDepartement(id);
            return NoContent();
        }
    }
}

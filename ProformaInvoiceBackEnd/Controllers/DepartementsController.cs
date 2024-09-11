using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly DepartementService _DepartementService;

        public DepartementsController(DepartementService departementService)
        {
            _DepartementService = departementService;

        }

        // POST: api/Departements/CreateDepartement
        [HttpPost("CreateDepartement")]
        public async Task<ActionResult<departementDTO>> CreateDepartement(departementDTO dto)
        {
            try
            {
                var createdDepartement = await _DepartementService.CreateDepartement(dto);
                return Ok(createdDepartement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}");
            }
        }

        // GET: api/Departements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<departementDTO>>> GetAllDepartements()
        {
            try
            {
                var departements = await _DepartementService.GetAllDepartements();
                return Ok(departements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        // GET: api/Departements/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<departementDTO>> GetDepartementById(int id)
        {
            try
            {
                var departement = await _DepartementService.GetDepartementsById(id);
                if (departement == null)
                {
                    return NotFound();
                }
                return Ok(departement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        // PUT: api/Departements/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartement(int id, departementDTO dto)
        {
            try
            {
                var updateDepartement = await _DepartementService.UpdateDepartement(id, dto);
                if (updateDepartement == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la mise à jour de l'élément : {ex.Message}");
            }
        }

        // DELETE: api/Departements/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartement(int id)
        {
            try
            {
                var result = await _DepartementService.DeleteDepartement(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la suppression de l'élément : {ex.Message}");
            }
        }


        [HttpGet("searchManagers")]
        public async Task<ActionResult<IEnumerable<string>>> SearchManagers(string query)
        {
            try
            {
                var managers = await _DepartementService.SearchManagers(query);
                return Ok(managers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while searching for managers: {ex.Message}");
            }
        }

    }
}

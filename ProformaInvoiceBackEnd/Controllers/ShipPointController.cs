using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipPointController : ControllerBase
    {
        private readonly ShipPointService _shipPointService;

        public ShipPointController(ShipPointService shipPointService)
        {
            _shipPointService = shipPointService;
        }

        // POST: api/ShipPoint/CreateShipPoint
        [HttpPost()]
        public async Task<ActionResult<shipPointDTO>> CreateShipPoint(shipPointDTO ship)
        {
            try
            {
                await _shipPointService.CreateShipPoint(ship);
                return Ok(new {message="Created"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément de visite : {ex.Message}");
            }
        }

        // GET: api/ShipPoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<shippoint>>> GetAllShipPoints()
        {
            try
            {
                var shipPoints = await _shipPointService.GetAllshipPoints();
                return Ok(shipPoints);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        // GET: api/ShipPoint/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<shipPointDTO>> GetShipPointById(int id)
        {
            try
            {
                var shipPoint = await _shipPointService.GetshipPointById(id);
                if (shipPoint == null)
                {
                    return NotFound();
                }
                return Ok(shipPoint);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        // PUT: api/ShipPoint/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipPoint(int id, shipPointDTO dto)
        {
            try
            {
                var updatedShipPoint = await _shipPointService.UpdateshipPoint(id, dto);
                if (updatedShipPoint == null)
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

        // DELETE: api/ShipPoint/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipPoint(int id)
        {
            try
            {
                var result = await _shipPointService.DeleteshipPoint(id);
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
    }
}

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
    public class plantsController : ControllerBase
    {
        private readonly plantService _plantService;

        public plantsController(plantService plantService)
        {
            _plantService = plantService;

        }

        // GET: api/plants
        [HttpPost("CreatePlant")]
        public async Task<ActionResult<plantDTO>> CreatePlant(plantDTO dto)
        {
            try
            {
                var createdPlant = await _plantService.CreatePlant(dto);
                return Ok(createdPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}");
            }
        }

        //get all palnts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<plantDTO>>> GetAllPlants()
        {
            try
            {
                var plants = await _plantService.GetAllPlants();
                return Ok(plants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        //get plant by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<plantDTO>> GetPlantById(int id)
        {
            try
            {
                var plant = await _plantService.GetPlantById(id);
                if (plant == null)
                {
                    return NotFound();
                }
                return Ok(plant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        //update plant 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlant(int id, plantDTO dto)
        {
            try
            {
                var updatePlant = await _plantService.UpdatePlant(id, dto);
                if (updatePlant == null)
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

        //delete plant
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            try
            {
                var result = await _plantService.DeletePlant(id);
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
        [HttpGet("searchManagerPlants")]
        public async Task<ActionResult<IEnumerable<string>>> SearchManagers(string query)
        {
            try
            {
                var managerPlants = await _plantService.SearchManagerPlants(query);
                return Ok(managerPlants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while searching for managers: {ex.Message}");
            }
        }

    }
}

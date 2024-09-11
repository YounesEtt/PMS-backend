using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly PlantService _plantService;

        public PlantController(PlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        public IActionResult GetAllPlants()
        {
            var plants = _plantService.GetAllPlants();
            return Ok(plants);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlantById(int id)
        {
            var plant = _plantService.GetPlantById(id);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        [HttpPost]
        public IActionResult CreatePlant([FromBody] plant plant)
        {
            var createdPlant = _plantService.CreatePlant(plant);
            return CreatedAtAction(nameof(GetPlantById), new { id = createdPlant.Id_plant }, createdPlant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlant(int id, [FromBody] plant plant)
        {
            _plantService.UpdatePlant(id, plant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlant(int id)
        {
            _plantService.DeletePlant(id);
            return NoContent();
        }
    }
}

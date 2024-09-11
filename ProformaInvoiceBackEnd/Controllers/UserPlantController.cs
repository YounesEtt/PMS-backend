using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlantController : ControllerBase
    {
        private readonly UserPlantService _userPlantService;

        public UserPlantController(UserPlantService userPlantService)
        {
            _userPlantService = userPlantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserPlant(UserPlantDTO dto)
        {
            var userPlant = await _userPlantService.CreateUserPlant(dto);
            return CreatedAtAction(nameof(GetUserPlantById), new { id = userPlant.Id }, userPlant);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserPlants()
        {
            var userPlants = await _userPlantService.GetAllUserPlants();
            return Ok(userPlants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPlantById(int id)
        {
            var userPlant = await _userPlantService.GetUserPlantById(id);
            if (userPlant == null) return NotFound();
            return Ok(userPlant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserPlant(int id, UserPlantDTO dto)
        {
            var result = await _userPlantService.UpdateUserPlant(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPlant(int id)
        {
            var result = await _userPlantService.DeleteUserPlant(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

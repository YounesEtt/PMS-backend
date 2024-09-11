using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioItemConfigurationController : ControllerBase
    {
        private readonly scenarioItemsconfigurationservice _ScenarioItemsconfigurationservicee;

        public ScenarioItemConfigurationController(scenarioItemsconfigurationservice scenarioItemsconfigurationservice)
        {
            _ScenarioItemsconfigurationservicee = scenarioItemsconfigurationservice;

        }

        [HttpGet("GetByScenario/{scenarioId}")]
        public async Task<ActionResult<IEnumerable<scenario_items_configurationDTO>>> GetConfigurationsByScenario(int scenarioId)
        {
            try
            {
                var configurations = await _ScenarioItemsconfigurationservicee.GetConfigurationsByScenario(scenarioId);
                return Ok(configurations);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("UpdateByScenario/{scenarioId}")]
        public async Task<IActionResult> UpdateConfigurations(int scenarioId, [FromBody] List<scenario_items_configurationDTO> configurationsDto)
        {
            try
            {
                await _ScenarioItemsconfigurationservicee.UpdateConfigurations(scenarioId, configurationsDto);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/ScenarioItemConfigurations
        [HttpPost("CreateScenarioItemConfiguration")]
        public async Task<ActionResult<scenario_items_configurationDTO>> CreateScenarioItemConfiguration(scenario_items_configurationDTO dto)
        {
            try
            {
                var createdScenarioItemConfig = await _ScenarioItemsconfigurationservicee.CreatescenarioItemsConfiguration(dto);
                return Ok(createdScenarioItemConfig);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}");
            }
        }

        //get all ScenarioItemConfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<scenario_items_configurationDTO>>> GetAllScenarioItemConfigurations()
        {
            try
            {
                var ScenarioItemConfigurations = await _ScenarioItemsconfigurationservicee.GetAllscenarioItemsConfigurations();
                return Ok(ScenarioItemConfigurations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        //get ScenarioItemConfiguration by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<scenario_items_configurationDTO>> GetScenarioItemsconfigurationById(int id)
        {
            try
            {
                var ScenarioItemConfiguration = await _ScenarioItemsconfigurationservicee.GetscenarioItemsConfigurationById(id);
                if (ScenarioItemConfiguration == null)
                {
                    return NotFound();
                }
                return Ok(ScenarioItemConfiguration);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        //update ScenarioItemConfiguration 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartement(int id, scenario_items_configurationDTO dto)
        {
            try
            {
                var updateScenarioItemConfiguration = await _ScenarioItemsconfigurationservicee.UpdatescenarioItemsConfiguration(id, dto);
                if (updateScenarioItemConfiguration == null)
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

        //delete ScenarioItemConfiguration
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartement(int id)
        {
            try
            {
                var result = await _ScenarioItemsconfigurationservicee.DeletescenarioItemsConfiguration(id);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly ScenarioService _scenarioService;

        public ScenarioController(ScenarioService scenarioService)
        {
            _scenarioService = scenarioService;

        }

        // POST: api/scenarios
        [HttpPost("CreateScenario")]
        public async Task<ActionResult<scenarioDTO>> CreateScenario(scenarioDTO dto)
        {
            try
            {
                var createScenario = await _scenarioService.Createscenario(dto);
                return Ok(new { id_scenario = createScenario.Id_scenario, message = "Created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}");
            }
        }

        // GET: api/Scenario/{scenarioId}/attributes
        [HttpGet("{scenarioId}/attributes")]
        public async Task<ActionResult<IEnumerable<scenarioItemsDTO>>> GetScenarioAttributes(int scenarioId)
        {
            try
            {
                var scenarioAttributes = await _scenarioService.GetScenarioAttributes(scenarioId);
                return Ok(scenarioAttributes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des attributs du scénario : {ex.Message}");
            }
        }

        // GET: api/Scenario/{scenarioId}/approvers
        [HttpGet("{scenarioId}/approvers")]
        public async Task<ActionResult<IEnumerable<approverScenarioDTO>>> GetApproversByScenarioId(int scenarioId)
        {
            try
            {
                var approvers = await _scenarioService.GetApproversByScenarioId(scenarioId);
                return Ok(approvers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des approbateurs du scénario : {ex.Message}");
            }
        }

        //get all scenarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<scenarioDTO>>> GetAllScenarios()
        {
            try
            {
                var scenarios = await _scenarioService.GetAllScenarios();
                return Ok(scenarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        //get scenario by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<scenarioDTO>> GetScenarioById(int id)
        {
            try
            {
                var scenario = await _scenarioService.GetScenarioById(id);
                if (scenario == null)
                {
                    return NotFound();
                }
                return Ok(scenario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        //update scenario 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScenario(int id, scenarioDTO dto)
        {
            try
            {
                var updateScenario = await _scenarioService.UpdateScenario(id, dto);
                if (updateScenario == null)
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

        //delete scenario
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScenario(int id)
        {
            try
            {
                var result = await _scenarioService.DeleteScenario(id);
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

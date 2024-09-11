using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproverScenarioController : ControllerBase
    {
        private readonly ApproverScenarioService _approverService;

        public ApproverScenarioController(ApproverScenarioService approverService)
        {
            _approverService = approverService;

        }

        // POST: api/approvers
        [HttpPost("CreateApprover")]
        public async Task<ActionResult<approverScenarioDTO>> CreateApprover(approverScenarioDTO dto)
        {
            try
            {
                var createdPlant = await _approverService.CreateApprover(dto);
                return Ok(new { message = "Created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}");
            }
        }

        //get all Approvers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<approverScenarioDTO>>> GetAllApprovers()
        {
            try
            {
                var approvers = await _approverService.GetAllApprovers();
                return Ok(approvers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        //get Approver by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<approverScenarioDTO>> GetApproverById(int id)
        {
            try
            {
                var approver = await _approverService.GetApproverById(id);
                if (approver == null)
                {
                    return NotFound();
                }
                return Ok(approver);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        //update Approver 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApprover(int id, approverScenarioDTO dto)
        {
            try
            {
                var updateApprover = await _approverService.UpdateApprover(id, dto);
                if (updateApprover == null)
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

        //delete Approver
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApprover(int id)
        {
            try
            {
                var result = await _approverService.DeleteApprover(id);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproverRequestController : ControllerBase
    {
        private readonly ApproverRequestService _approverRequestService;

        public ApproverRequestController(ApproverRequestService approverRequestService)
        {
            _approverRequestService = approverRequestService;
        }

        // POST: api/approversRequest
        [HttpPost("CreateApproverRequest")]
        public async Task<ActionResult<CreateApproverRequestDTO>> CreateApproverRequest(CreateApproverRequestDTO dto)
        {
            try
            {
                var createdPlant = await _approverRequestService.CreateApproverRequest(dto);
                return Ok(new { message = "Created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}");
            }
        }
    }
}

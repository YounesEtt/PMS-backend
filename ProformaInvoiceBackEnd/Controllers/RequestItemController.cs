using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestItemController : ControllerBase
    {
        private readonly RequestItemService _requestItemService;

        public RequestItemController(RequestItemService requestItemService)
        {
            _requestItemService = requestItemService;

        }

        // GET: api/RequestItems
        [HttpPost("CreateRequestItem")]
        public async Task<ActionResult<request_itemDTO>> CreateRequestItem(request_itemDTO dto)
        {
            try
            {
                var createRequestItem = await _requestItemService.CreateRequestItem(dto);
                return Ok(createRequestItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Une erreur s'est produite lors de la création de l'élément : {ex.Message}" });
            }
        }
        //get all requestsitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<request_itemDTO>>> GetAllRequestItems()
        {
            try
            {
                var request_Items = await _requestItemService.GetAllRequestItems();
                return Ok(request_Items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        //get  by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<request_itemDTO>> GetRequestItemById(int id)
        {
            try
            {
                var request_Item = await _requestItemService.GetRequestItemById(id);
                if (request_Item == null)
                {
                    return NotFound();
                }
                return Ok(request_Item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        //update user 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestItem(int id, request_itemDTO dto)
        {
            try
            {
                var updateRequestItem = await _requestItemService.UpdateRequestItem(id, dto);
                if (updateRequestItem == null)
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

        //delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestItem(int id)
        {
            try
            {
                var result = await _requestItemService.DeleteRequestItem(id);
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

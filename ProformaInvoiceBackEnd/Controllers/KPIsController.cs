using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.Services;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPIsController : ControllerBase
    {
        private readonly KPIsService _kpiService;
        private readonly RequestService _requestService;

        public KPIsController(KPIsService kpiService)
        {
            _kpiService = kpiService;
        }

       
        [HttpGet("requests-by-all-scenarios")]
        public IActionResult GetRequestCountByAllScenarios()
        {
            var counts = _kpiService.GetRequestCountByAllScenarios();
            return Ok(counts);
        }

        [HttpGet("all-requests")]
        public IActionResult GetAllRequests()
        {
            var requests = _kpiService.GetAllRequests();
            return Ok(requests);
        }

        [HttpGet("requests-by-costcenter-per-scenario")]
        public IActionResult GetRequestCountByCostCenterPerScenario()
        {
            try
            {
                var counts = _kpiService.GetRequestCountByCostCenterPerScenario();
                return Ok(counts);
            }
            catch (Exception ex)
            {
                // Log the error (you can use any logging framework)
                Console.WriteLine($"Error retrieving counts by cost center per scenario: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("requests-by-costcenter-per-day")]
        public IActionResult GetRequestCountByCostCenterPerDay()
        {
            try
            {
                var result = _kpiService.GetRequestCountByCostCenterPerDay();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the error (you can use any logging framework)
                Console.WriteLine($"Error retrieving counts by cost center per day: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("average-flow-time-all-requests")]
        public IActionResult GetAverageFlowTimeForAllRequests()
        {
            var averageFlowTimes = _kpiService.GetAverageFlowTimeForAllRequests();
            return Ok(averageFlowTimes);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using ProformaInvoiceBackEnd.Services;
using System.Diagnostics;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using AutoMapper;
using ClosedXML.Excel;
using System.Data;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace ProformaInvoiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;
        private readonly ApproverRequestService _approverRequestService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;

        public RequestController(RequestService requestService,
            ApproverRequestService approverRequestService, 
            IMapper mapper, ApplicationDbContext context,
            IConverter converter)
        {
            _requestService = requestService;
            _approverRequestService = approverRequestService;
            _mapper = mapper;
            _context = context;
            _converter = converter;
        }

        // POST: api/Request/CreateRequest
        [HttpPost("CreateRequest")]
        public async Task<ActionResult<CreateRequestDTO>> CreateRequest(CreateRequestDTO dto)
        {
            try
            {
                var request = await _requestService.CreateRequest(dto);
                return Ok(new { message = "created" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // Output exception to debug console
                return StatusCode(500, $"Une erreur s'est produite lors de la création de la requête : {ex.Message} | Inner Exception: {ex.InnerException?.Message}");
            }
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<request>>> GetAllRequests()
        {
            try
            {
                var requests = await _requestService.GetAllRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des éléments : {ex.Message}");
            }
        }

        // GET: api/Request/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateRequestDTO>> GetRequestById(int id)
        {
            try
            {
                var request = await _requestService.GetRequestById(id);
                if (request == null)
                {
                    return NotFound();
                }
                var requestDto = _mapper.Map<CreateRequestDTO>(request);
                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération de l'élément : {ex.Message}");
            }
        }

        // DELETE: api/Request/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            try
            {
                var result = await _requestService.DeleteRequest(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la suppression de la requête : {ex.Message}");
            }
        }

        // PUT: api/Request/UpdateRequestByFinance/{id}
        [HttpPut("UpdateRequestByFinance/{id}")]
        public async Task<IActionResult> UpdateRequestByFinance(int id, UpdateFinanceRequestDTO dto)
        {
            try
            {
                var result = await _requestService.UpdateRequestByFinance(id, dto);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la mise à jour de la requête par la finance : {ex.Message}");
            }
        }

        // PUT: api/Request/UpdateRequestByTradCompliance/{id}
        [HttpPut("UpdateRequestByTradCompliance/{id}")]
        public async Task<IActionResult> UpdateRequestByTradCompliance(int id, UpdateTradComplianceRequestDTO dto)
        {
            try
            {
                var result = await _requestService.UpdateRequestByTradCompliance(id, dto);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la mise à jour de la requête par la conformité commerciale : {ex.Message}");
            }
        }

        // PUT: api/Request/UpdateRequestByWarehouse/{id}]
        [HttpPut("UpdateRequestByWarehouse/{id}")]
        public async Task<IActionResult> UpdateRequestByWarehouse(int id, UpdateWarehouseRequestDTO dto)
        {
            try
            {
                var result = await _requestService.UpdateRequestByWarehouse(id, dto);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(result); // Assurez-vous que le résultat contient les données mises à jour
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la mise à jour de la requête par l'entrepôt : {ex.Message}");
            }
        }

        // PUT: api/Request/RejectRequest/{id}]
        [HttpPut("RejectRequest/{id}")]
        public async Task<IActionResult> RejectRequest(int id, RejectRequestDTO dto)
        {
            try
            {
                var result = await _requestService.RejectRequest(id, dto);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors du rejet de la requête : {ex.Message}");
            }
        }

        // GET: api/Request/{requestId}/invoice
        [HttpGet("{requestId}/invoice")]
        public async Task<IActionResult> DownloadInvoice(int requestId)
        {
            var request = await _requestService.GetRequestById(requestId);
            if (request == null)
            {
                return NotFound();
            }

            string htmlContent = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        body {{
            font-family: Arial, sans-serif;
            font-size: 0.8em;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            width: 100%;
            margin: 0 auto;
        }}
        .invoice-header {{
            margin-bottom: 10px;
        }}
        .invoice-details, .invoice-address {{
            margin-bottom: 10px;
        }}
        .table td, .table th {{
            vertical-align: middle;
            border: 1px solid #000;
            padding: 5px;
            text-align: left;
        }}
        .table {{
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 5px;
            margin-top: 5px;
        }}
        .box {{
            border: 1px solid #000;
            padding: 10px;
            margin-bottom: 10px;
        }}
        .logo {{
            width: 100%;
            max-width: 100px;
        }}
       
        .header-right {{
            text-align: right;
        }}
        .header-left {{
            text-align: left;
        }}
        .address-table {{
            width: 100%;
            border-collapse: collapse;
        }}
        .address-table td {{
            vertical-align: top;
            padding: 5px;
            border: 1px solid #000;

        }}
        .tdT {{
            text-align: right;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='invoice-header'>
            <div class='header-right'>
                <h4>Invoice date: {request.created_at?.ToString("dd-MM-yyyy")}</h4>
                <h4>Shipment N°: P {DateTime.Now.ToString("yy")} {request.RequestNumber}</h4>
            </div>
            <div class='header-left'>
                <h1>Proforma Invoice</h1>
            </div>
        </div>
        <table class='address-table'>
            <tr>
                <td>
                        <strong>Delivery address:</strong>
                        <p>{request.DeliveryAddress.Replace("\n", "<br>")}</p>
                </td>
                <td>
                        <strong>Invoice address:</strong>
                        <p>{request.InvoiceAddress.Replace("\n", "<br>")}</p> 
                </td>
            </tr>
        </table>
        <div class='box'>
            <strong>Mode of transport: {request.MODEOFTRANSPORT}</strong><br>
            <strong>Shipment date: {request.created_at?.ToString("dd-MM-yyyy")}</strong><br>
            <strong>Incoterms: {request.incoterm}</strong><br>
            <strong>Shipped Via: {request.SHIPPEDVIA}</strong>
        </div>
        <table class='table'>
            <thead>
                <tr>
                    <th>Item N°</th>
                    <th>Quantity ordered</th>
                    <th>Unit</th>
                    <th>Description</th>
                    <th>Unit price</th>
                    <th>Quantity delivered</th>
                    <th>Amount (EUR)</th>
                </tr>
            </thead>
            <tbody>
                {string.Join("", request.Item.Select((item, index) => $@"
                <tr>
                    <td>{index + 1}</td>
                    <td>{item.QUANTITY}</td>
                    <td>{item.UNITOFQUANTITY}</td>
                    <td>
                        item: {item.PN}<br>
                        Description: {item.DESCRIPTION}<br>
                        Commodity code: {request.HTSCODE}<br>
                        Country Of Origin: {request.COO}
                    </td>
                    <td>{item.UNITVALUEFINANCE}</td>
                    <td>{item.QUANTITY}</td>
                    <td>{item.UNITVALUEFINANCE * item.QUANTITY}</td>
                </tr>"))}
                <tr>
                    <td colspan='6' class='tdT'><strong>Total (EUR)</strong></td>
                    <td>{request.Item.Sum(item => (item.UNITVALUEFINANCE ?? 0) * (item.QUANTITY ?? 0))}</td>
                </tr>
            </tbody>
        </table>
        <div class='box'>
            <strong>Gross Weight: {request.WEIGHT} KG</strong><br>
            <strong>Net Weight: {request.WEIGHT} KG</strong><br>
            <strong>Number of parcels: {request.NUMBEROFBOXES}</strong><br>
            <strong>Dimension: {request.DIMENSION}</strong><br>
            <strong>VATX: Value for customs purpose only</strong>
        </div>
 <table class='address-table'>
            <tr>
                <td>
                        <strong>Exporter address:</strong>
                    <p>{request.ExporterAddress.Replace("\n", "<br>")}</p>
                </td>
                <td>
                         <strong>Shipped from:</strong>
                    <p>{request.ShippingPoint.Replace("\n", "<br>")}</p>
                </td>
            </tr>
        </table>
      
    </div>
</body>
</html>";

            var pdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                   FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = "Our General Terms and Conditions of Business will apply. They are available on request and can also be found under www.te.com/aboutus/tandc.asp" }
                    }
                }
            };

            byte[] pdf = _converter.Convert(pdfDocument);

            return File(pdf, "application/pdf", $"Invoice_{requestId}.pdf");
        }

        /**************************************************************************************************/
        // Export requests to Excel
        [HttpGet("ExportRequestsExcel")]
        public ActionResult ExportRequestsExcel()
        {
            var requests = GetRequestData();
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(requests, "Requests");

                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return new FileContentResult(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = "Requests.xlsx"
                    };
                }
            }
        }

        [NonAction]
        private DataTable GetRequestData()
        {
            var dt = new DataTable("Requests");
            dt.Columns.Add("RequestNumber", typeof(int));
            dt.Columns.Add("InvoicesTypes", typeof(string));
            dt.Columns.Add("ShippingPoint", typeof(string));
            dt.Columns.Add("DeliveryAddress", typeof(string));
            dt.Columns.Add("DHLACCOUNT", typeof(string));
            dt.Columns.Add("TRACKINGNUMBER", typeof(string));
            dt.Columns.Add("Incoterm", typeof(string));
            dt.Columns.Add("NumberOfBoxes", typeof(string));
            dt.Columns.Add("Weight", typeof(decimal));
            dt.Columns.Add("Dimension", typeof(string));
            dt.Columns.Add("OperationType", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("created_at", typeof(string));

            // Columns for Items
            dt.Columns.Add("ItemId", typeof(int));
            dt.Columns.Add("PN", typeof(string));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("UnitOfQuantity", typeof(string));
            dt.Columns.Add("UnitValueFinance", typeof(decimal));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("CostCenter", typeof(string));
            dt.Columns.Add("BusinessUnit", typeof(string));
            dt.Columns.Add("Plant", typeof(string));

            // Columns for User
            dt.Columns.Add("TeId", typeof(string));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Email", typeof(string));

            var requests = _context.request
                .Include(r => r.Item)
                .Include(r => r.User)// Assuming 'Item' is the navigation property
                .ToList();

            foreach (var request in requests)
            {
                foreach (var item in request.Item)
                {
                    dt.Rows.Add(
                        request.RequestNumber,
                        request.InvoicesTypes,
                        request.ShippingPoint,
                        request.DeliveryAddress,
                        request.DHLACCOUNT,
                        request.TRACKINGNUMBER,
                        request.incoterm,
                        request.NUMBEROFBOXES,
                        request.WEIGHT,
                        request.DIMENSION,
                        request.operationtype,
                        request.status,
                        request.created_at,
                        // Item details
                        item.id_items,
                        item.PN,
                        item.QUANTITY,
                        item.UNITOFQUANTITY,
                        item.UNITVALUEFINANCE,
                        item.DESCRIPTION,
                        item.COSTCENTER,
                        item.BUSINESSUNIT,
                        item.PLANT,
                         // User details
                        request.User?.TeId,
                        request.User?.UserName,
                        request.User?.email
                    );
                }
            }

            return dt;
        }
    }
}
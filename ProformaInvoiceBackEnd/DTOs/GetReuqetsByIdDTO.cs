using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.DTOs
{
    public class GetReuqetsByIdDTO
    {
        public string? InvoicesTypes { get; set; }
        public string? ShippingPoint { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Incoterm { get; set; }
        public int UserId { get; set; }
        public int ScenarioId { get; set; }
        public string? PN { get; set; }
        public decimal? Quantity { get; set; }
        public string? UnitOfQuantity { get; set; }
        public decimal? UnitValueFinance { get; set; }
        public string? Description { get; set; }
        public string? CostCenter { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Plant { get; set; }
        public string? DHLAccount { get; set; }
        public string? HTSCode { get; set; }
        public string? COO { get; set; }
        public string? TrackingNumber { get; set; }
        public int? NumberOfBoxes { get; set; }
        public decimal? Weight { get; set; }
        public RequestStatus? status { get; set; }
    }
}

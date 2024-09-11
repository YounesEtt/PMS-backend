using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.DTOs
{
    public class CreateRequestDTO
    {
        public string? InvoicesTypes { get; set; }
        public string? ShippingPoint { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Incoterm { get; set; }
        public int UserId { get; set; }
        public int ScenarioId { get; set; }
        public List<CreateItemDTO> Items { get; set; } = new List<CreateItemDTO>();
        public string? DHLAccount { get; set; }
        public string? HTSCode { get; set; }
        public string? COO { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Numberofboxes { get; set; }
        public decimal? Weight { get; set; }
        public string? operationtype { get; set; }
        public string? Dimension { get; set; }

        public class CreateItemDTO
        {
            public int? Id_items { get; set; }
            public string? PN { get; set; }
            public decimal? QUANTITY { get; set; }
            public string? UNITOFQUANTITY { get; set; }
            public decimal? UNITVALUEFINANCE { get; set; }
            public string? DESCRIPTION { get; set; }
            public string? COSTCENTER { get; set; }
            public string? BUSINESSUNIT { get; set; }
            public string? PLANT { get; set; }
        }
    }
}

namespace ProformaInvoiceBackEnd.DTOs
{
    public class UpdateWarehouseRequestDTO
    {
        public int userId { get; set; }
        public string TRACKINGNUMBER { get; set; }

        public string NUMBEROFBOXES { get; set; }

        public decimal WEIGHT { get; set; }
        public string? MODEOFTRANSPORT { get; set; }
        public string? SHIPPEDVIA { get; set; }
    }
}

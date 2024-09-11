namespace ProformaInvoiceBackEnd.DTOs
{
    public class UpdateTradComplianceRequestDTO
    {
        public int userId { get; set; }
        public string HTSCODE { get; set; }
        public string? COO { get; set; }
    }
}

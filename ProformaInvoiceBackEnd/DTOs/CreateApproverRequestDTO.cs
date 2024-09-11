namespace ProformaInvoiceBackEnd.DTOs
{
    public class CreateApproverRequestDTO
    {
        public string? role { get; set; }
        public int? classe {  get; set; }
        public int? RequestId { get; set; }
    }
}

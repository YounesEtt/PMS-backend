namespace ProformaInvoiceBackEnd.DTOs
{
    public class UpdateUserDTO
    {
        public string? TeId { get; set; }
        public String? UserName { get; set; }
        public String? email { get; set; }
        public string? nPlus1 { get; set; }
        public string? BackUp { get; set; }
        public String? Role { get; set; }
        public int DepartementId { get; set; }
        public List<int>? plantId { get; set; }
    }
}

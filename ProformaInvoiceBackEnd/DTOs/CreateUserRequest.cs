namespace ProformaInvoiceBackEnd.DTOs
{
    public class CreateUserRequest
    {
        public userDTO User { get; set; }
        public int[] plantId { get; set; }
    }
}

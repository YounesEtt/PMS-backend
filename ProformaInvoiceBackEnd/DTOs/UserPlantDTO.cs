using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.DTOs
{
    public class UserPlantDTO
    {
        public int Id { get; set; }
        public User user { get; set; } = null!;
        public plant plant { get; set; } = null!;
    }
}

namespace ProformaInvoiceBackEnd.DTOs
{
    public class UserWithPlantsDTO
    {
        public userDTO User { get; set; }
        public List<int> PlantIds { get; set; }
    }
}

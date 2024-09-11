namespace ProformaInvoiceBackEnd.DTOs
{
    public class CreateRequestDepartDTO
    {
        public departementDTO departement { get; set; }
        public int[] PlantIds { get; set; }
    }
}

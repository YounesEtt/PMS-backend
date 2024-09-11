using ProformaInvoiceBackEnd.Models;

namespace ProformaInvoiceBackEnd.DTOs
{
    public class scenario_items_configurationDTO
    {
        public int Id { get; set; }
        public int Id_scenario { get; set; }

        public int Id_request_item { get; set; }

        public bool IsMandatory { get; set; }
    }
}

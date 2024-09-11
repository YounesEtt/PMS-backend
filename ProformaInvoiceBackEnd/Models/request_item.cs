using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class request_item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_request_item { get; set; }
        public string nameItem { get; set; }
        public ICollection<scenario_items_configuration> scenarioItemsconfiguration { get; set; } // Change to ICollection

    }
}

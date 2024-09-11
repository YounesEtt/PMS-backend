using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class scenario_items_configuration
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Id_scenario { get; set; }
        public scenario Scenario { get; set; } = null!;

        public int Id_request_item { get; set; }
        public request_item RequestItem { get; set; } = null!;
        public bool IsMandatory { get; set; }
    }
}

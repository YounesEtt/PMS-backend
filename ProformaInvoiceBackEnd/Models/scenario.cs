using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class scenario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_scenario { get; set; }
        public string name { get; set; }
        public ICollection<scenario_items_configuration> scenarioItemsconfiguration { get; set; }
    }
}
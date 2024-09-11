using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class approverscenario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_approver {  get; set; }
        public string role { get; set; }
        public int classe { get; set; }
        public int scenarioId { get; set; }
        public scenario scenario { get; set; }
    }
}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class shippoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ship { get; set; }
        public string shipPoint { get; set; }
        public string FullAddress { get; set; }
    }
}

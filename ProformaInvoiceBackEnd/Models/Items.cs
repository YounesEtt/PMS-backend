using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_items { get; set; }   
        public string? PN { get; set; }
        public decimal? QUANTITY { get; set; }
        public string? UNITOFQUANTITY { get; set; }
        public decimal? UNITVALUEFINANCE { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? COSTCENTER { get; set; }
        public string? BUSINESSUNIT { get; set; }
        public string? PLANT { get; set; }
        public int RequestNumber {  get; set; } 
        public request request { get; set; }    

    }
}

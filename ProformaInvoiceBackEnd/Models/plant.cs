using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class plant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_plant { get; set; } 
        public string plantNumber { get; set; }
        public String Location { get; set; }
        public string Manager_plant { get; set; }
        public string Building_id { get; set; }    
        public string businessUnit { get; set; }
        public ICollection<UserPlant> UserPlants { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ProformaInvoiceBackEnd.Models
{
    public class UserPlant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User user { get; set; } = null!;

        public int Id_plant { get; set; }
        public plant plant { get; set; } = null!;

    }
}

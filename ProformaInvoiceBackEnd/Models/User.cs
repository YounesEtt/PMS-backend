using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProformaInvoiceBackEnd.Models
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string TeId { get; set; }
        public String UserName { get; set; }
        public String email { get; set; }
        public string? nPlus1 { get; set; }
        public string BackUp { get; set; }
        public String? Role { get; set; }
        public String Pwd { get; set; }
        public int DepartementId { get; set; }
        public Departement Departement { get; set; }
        public ICollection<UserPlant> UserPlants { get; set; }

    }
}

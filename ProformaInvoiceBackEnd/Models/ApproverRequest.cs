using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProformaInvoiceBackEnd.Models
{
    public class ApproverRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_approverrequest { get; set; }
        public int? userId { get; set; }
        public RequestStatus? status { get; set; }
        public DateTime? Date {  get; set; }
        public DateTime? status_datetime { get; set; }
        public string? comment { get; set; }
        public int? RequestId { get; set; }
        public request request { get; set; }
        public string? role { get; set; }
        public int? classe { get; set; }
    }
}

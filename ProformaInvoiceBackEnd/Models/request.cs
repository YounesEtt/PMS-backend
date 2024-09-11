using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication.ExtendedProtection;
using System.ComponentModel;

namespace ProformaInvoiceBackEnd.Models
{
    public class request
    {
        internal string CostCenter;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestNumber { get; set; }
        public string? InvoicesTypes { get; set; }
        public string? ShippingPoint { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? incoterm { get; set; }
        public DateTime? created_at { get; set; }
        public int? userId { get; set; }
        public virtual User? User { get; set; }
        public int? scenarioId { get; set; }
        public virtual scenario? Scenario { get; set; }
        public int? shipId { get; set; }
        public virtual shippoint? shippoint { get; set; }

        [Required]
        [DefaultValue(RequestStatus.PendingInFinance)]
        public RequestStatus? status { get; set; } = RequestStatus.PendingInFinance;
        public string? operationtype { get; set; }
        
        public string? DHLACCOUNT { get; set; }
        public string? HTSCODE { get; set; }
        public string? COO { get; set; }
        public string? TRACKINGNUMBER { get; set; }
        public string? NUMBEROFBOXES { get; set; }
        public decimal? WEIGHT { get; set; }
        public string? DIMENSION { get; set; }
        public string? InvoiceAddress { get; set; }
        public string? ExporterAddress { get; set; }
        public string? MODEOFTRANSPORT { get; set; }
        public string? SHIPPEDVIA { get; set; }

        public virtual ICollection<ApproverRequest> ApproverRequest { get; set; }
        public virtual ICollection<Items> Item { get; set; } = new List<Items>();
    }

    public enum RequestStatus
    {
        PendingInFinance,
        PendingInTradCompliance,
        InShipping,
        Done,
        Rejected,
    }
}
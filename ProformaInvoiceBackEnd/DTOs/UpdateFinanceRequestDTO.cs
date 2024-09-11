namespace ProformaInvoiceBackEnd.DTOs
{
    public class UpdateFinanceRequestDTO
    {
        public int userId { get; set; }
        public string incoterm { get; set; }
        public string dhlAccount { get; set; }
        public List<UpdateFinanceItemDTO> Items { get; set; }
    }

    public class UpdateFinanceItemDTO
    {
        public int id_items { get; set; }
        public decimal UNITVALUEFINANCE { get; set; }
    }
}

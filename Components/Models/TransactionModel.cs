namespace BlazorAppWeb.Components.Models
{
    public class TransactionModel
    {
        public string? description { get; set; } = string.Empty;
        public string? transaction_type { get; set; } = string.Empty;
        public decimal transaction_nominal { get; set; } = 0;
        public DateTime transaction_date { get; set; } = DateTime.Now;
        public int user_id { get; set; } = 0;
    }

    public class Transactions {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; 
        public decimal Nominal { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
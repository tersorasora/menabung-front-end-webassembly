namespace BlazorAppWeb.Components.Models
{
    public class RecapTransactions
    {
        public string Period { get; set; } = string.Empty;
        public decimal TotalIncome { get; set; } = 0;
        public decimal TotalExpense { get; set; } = 0;
        public decimal RemainderBalance { get; set; } = 0;
    }
}
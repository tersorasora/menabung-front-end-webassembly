namespace BlazorAppWeb.Components.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool Banned { get; set; } = false;
        public string Role { get; set; } = string.Empty;
        public int TotalTransactions { get; set; }
    }

    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Nominal { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
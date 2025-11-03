namespace BlazorAppWeb.Components.Models
{
    public class UserModel 
    {
        public string Username { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public int TotalTransactions { get; set; }
    }
}
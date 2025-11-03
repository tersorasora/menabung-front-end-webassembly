namespace BlazorAppWeb.Components.Models
{
    public class RegisterModel
    {
        public string Username { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterResult
    {
        public string Message { get; set; } = string.Empty;
    }
}
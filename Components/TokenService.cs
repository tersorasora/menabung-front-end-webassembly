using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using System.Threading.Tasks;

public class TokenService
{
    private readonly IJSRuntime _js;
    public string? Token { get; private set; }
    public string? UserId { get; private set; }
    public string? Nickname { get; private set; }
    public string? RoleId { get; private set; }
    public DateTime? Expiration { get; private set; }
    private bool _initialized = false;

    public TokenService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task InitializeAsync()
    {
        // Inititialize only once, and if refresh page will re initialize
        if (_initialized)
            return;

        _initialized = true;
        Token = await _js.InvokeAsync<string>("localStorage.getItem", "token");

        if (string.IsNullOrEmpty(Token))
            return;

        ParseToken(Token);
    }

    private void ParseToken(string token)
    {
        try
        {
            var parts = token.Split('.');
            if (parts.Length < 2) return;

            var payloadJson = System.Text.Encoding.UTF8.GetString(ParseBase64WithoutPadding(parts[1]));
            var payload = System.Text.Json.JsonDocument.Parse(payloadJson);

            UserId = payload.RootElement.GetProperty("sub").GetString();
            Nickname = payload.RootElement.GetProperty("nickname").GetString();
            RoleId = payload.RootElement.GetProperty("role_id").GetString();

            if (payload.RootElement.TryGetProperty("exp", out var exp))
            {
                var expSeconds = exp.GetInt64();
                Expiration = DateTimeOffset.FromUnixTimeSeconds(expSeconds).UtcDateTime;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing token: {ex.Message}");
        }
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }

    public bool IsTokenExpired()
    {
        if (Expiration == null) return true;
        return DateTime.UtcNow > Expiration;
    }
}
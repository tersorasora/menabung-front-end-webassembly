using Microsoft.JSInterop;

public class AuthService
{
    private readonly IJSRuntime _js;

    public AuthService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "token");
        return !string.IsNullOrEmpty(token);
    }

    public async Task LogoutAsync()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", "token");
    }
}
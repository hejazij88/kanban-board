using Kabnab_Board.Application.DTOs;
using System.Net;

namespace Kanban_Board.Presentation.Services;

public class UserServices
{
    private readonly HttpClient _httpClient;

    public UserServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> RegisterUser(RegisterDTO registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/User/RegisterUser", registerDto);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var result = await response.Content.ReadFromJsonAsync<bool>();

            return true;
        }

        return false;
    }

    public async Task<bool> LoginUser(LoginDTO logInDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/User/LoginUser", logInDto);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var result = await response.Content.ReadFromJsonAsync<string>();
            //Save Token In LocalStoreg
            return true;
        }

        return false;
    }
}
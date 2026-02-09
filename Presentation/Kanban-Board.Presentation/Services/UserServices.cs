using Kabnab_Board.Application.DTOs;

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
        var response = await _httpClient.PostAsJsonAsync("api/User/LoadUser", registerDto);


    }
}
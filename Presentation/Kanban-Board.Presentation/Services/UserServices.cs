using Kabnab_Board.Application.DTOs;
using System.Net;
using MudBlazor;

namespace Kanban_Board.Presentation.Services;

public class UserServices
{
    private readonly HttpClient _httpClient;

    private ISnackbar _snackbar;
    public UserServices(HttpClient httpClient, ISnackbar snackbar)
    {
        _httpClient = httpClient;
        _snackbar = snackbar;
    }

    public async Task<bool> RegisterUser(RegisterDTO registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/RegisterUser", registerDto);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Register Is Success", Severity.Success);
            return true;
        }

        var result = await response.Content.ReadFromJsonAsync<List<string>>();
        foreach (var error in result)
        {
            _snackbar.Add(error, Severity.Error);
        }
        return false;
    }

    public async Task<bool> LoginUser(LoginDTO logInDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Users/LoginUser", logInDto);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var result = await response.Content.ReadFromJsonAsync<string>();
            //Save Token In LocalStoreg
            return true;
        }

        return false;
    }
}
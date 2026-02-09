using Kabnab_Board.Application.DTOs;
using Kanban_Board.Presentation.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Kanban_Board.Presentation.Components.Pages;

public partial class Auth
{
    [Inject] private  UserServices _userServices { get; set; }
    [Inject] private ISnackbar _snackbar { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    private bool isLoginValid;
    private MudForm loginForm;
    private string loginEmail;
    private string loginPassword;
    private bool isRegisterValid;
    private MudForm registerForm;
    private RegisterDTO registerDTO = new RegisterDTO();

    private async Task OnLoginClick()
    {
        await loginForm.Validate();
        if (isLoginValid)
        {
            /* اجرای عملیات لاگین */
        }
    }

    private async Task OnRegisterClick()
    {
        await registerForm.Validate();
        if (isRegisterValid)
        {
             var result=await _userServices.RegisterUser(registerDTO);
             if (result == true)
             {
                 _snackbar.Add("Register Success", Severity.Success);
                 _navigationManager.NavigateTo("/Auth");
             }
             _snackbar.Add("Register Failed", Severity.Error);

        }
    }
}
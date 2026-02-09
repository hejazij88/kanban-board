using Kabnab_Board.Application.DTOs;
using MudBlazor;

namespace Kanban_Board.Presentation.Components.Pages;

public partial class Auth
{
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
            /* اجرای عملیات ثبت‌نام */
        }
    }
}
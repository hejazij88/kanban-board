using Kabnab_Board.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace kanban_board.API.Controllers;

[Route("api/[controller]")]

public class UserController : ControllerBase
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterDTO registerDto)
    {
        await _mediator.Send(registerDto);
        return Ok();
    }


    [HttpPost]
    public async Task<IActionResult> LoginUser(LoginDTO loginDto)
    {
        var result = await _mediator.Send(loginDto);
        return Ok(result);
    }
}
using Kabnab_Board.Application.Commands;
using Kabnab_Board.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace kanban_board.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
        
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO registerDto)
    {
        var command = new RegisterUserCommand(registerDto.Email, registerDto.Password, registerDto.Fullname);
        var result = await _mediator.Send(command);

        if(result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }


    [HttpPost("LoginUser")]
    public async Task<IActionResult> LoginUser(LoginDTO loginDto)
    {
        var result = await _mediator.Send(loginDto);
        return Ok(result);
    }
}
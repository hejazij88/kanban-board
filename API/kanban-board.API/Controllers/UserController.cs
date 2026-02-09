using Kabnab_Board.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace kanban_board.API.Controllers
{
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
            var result = (bool)(await _mediator.Send(registerDto) ?? false);
            return Ok(result);
        }
    }
}

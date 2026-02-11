using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using MediatR;

namespace Kabnab_Board.Application.Commands.Handlers;

public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Email = request.email,
            UserName = request.email,
            FullName = request.fullName,
        };

        await _userRepository.RegisterUser(user,request.password);
    }
}
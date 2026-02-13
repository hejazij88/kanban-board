using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using MediatR;

namespace Kabnab_Board.Application.Commands.Handlers;

public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommand,Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Email = request.email,
            UserName = request.email,
            FullName = request.fullName,
        };

        var result = await _userRepository.RegisterUser(user, request.password);
        if (result== false)
            return Result<bool>.Failure(new List<string> { "User registration failed" });

        return Result<bool>.Success(result);
    }
}
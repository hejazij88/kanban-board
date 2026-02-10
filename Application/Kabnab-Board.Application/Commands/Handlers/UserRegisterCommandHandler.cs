using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using MediatR;

namespace Kabnab_Board.Application.Commands.Handlers;

public class UserRegisterCommandHandler:IRequestHandler<UserRegisterCommand ,bool>
{
    private readonly IUserRepository _userRepository;

    public UserRegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new ApplicationUser
            {
                Email = request.Dto.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Dto.Password, 13),
                FirstName = request.Dto.UserName
            };

            _userRepository.RegisterUser(user);
            _userRepository.SaveChange();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
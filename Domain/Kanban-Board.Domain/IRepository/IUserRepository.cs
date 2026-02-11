using Kanban_Board.Domain.Models;

namespace Kanban_Board.Domain.IRepository;

public interface IUserRepository
{
    public Task<bool> RegisterUser(ApplicationUser applicationUser,string password);
    public Task<string> LogInUser(ApplicationUser applicationUser);
}
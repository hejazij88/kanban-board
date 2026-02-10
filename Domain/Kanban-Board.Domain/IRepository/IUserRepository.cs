using Kanban_Board.Domain.Models;

namespace Kanban_Board.Domain.IRepository;

public interface IUserRepository
{
    public Task RegisterUser(ApplicationUser applicationUser);
    public Task<string> LogInUser(ApplicationUser applicationUser);
}
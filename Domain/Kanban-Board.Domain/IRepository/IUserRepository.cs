using Kanban_Board.Domain.Models;

namespace Kanban_Board.Domain.IRepository;

public interface IUserRepository
{
    public void RegisterUser(ApplicationUser applicationUser);
}
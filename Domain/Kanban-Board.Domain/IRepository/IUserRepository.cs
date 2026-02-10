using Kanban_Board.Domain.Models;

namespace Kanban_Board.Domain.IRepository;

public interface IUserRepository:IRepositoryBase<ApplicationUser>
{
    public void RegisterUser(ApplicationUser applicationUser);
    public Task<ApplicationUser> FindUser(string userName);
}
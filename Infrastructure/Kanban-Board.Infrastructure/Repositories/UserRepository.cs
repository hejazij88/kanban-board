using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using Kanban_Board.Infrastructure.Data;

namespace Kanban_Board.Infrastructure.Repositories;

public class UserRepository:IUserRepository
{
    private readonly KanbanBoardContext _context;

    public UserRepository(KanbanBoardContext context)
    {
        _context = context;
    }

    public void RegisterUser(ApplicationUser applicationUser)
    {
        _context.ApplicationUsers.Add(applicationUser);
    }
}
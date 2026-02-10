using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using Kanban_Board.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Board.Infrastructure.Repositories;

public class UserRepository:RepositoryBase<ApplicationUser>,IUserRepository
{
    private readonly KanbanBoardContext _context;

    public UserRepository(KanbanBoardContext context) : base(context)
    {

    }

    public async void RegisterUser(ApplicationUser applicationUser)
    {
       await _context.ApplicationUsers.AddAsync(applicationUser);
    }

    public async Task<ApplicationUser> FindUser(string userName)
    {
     var user =await  _context.ApplicationUsers.FirstOrDefaultAsync(u=>u.FirstName==userName);
     return user??new ();
    }
}
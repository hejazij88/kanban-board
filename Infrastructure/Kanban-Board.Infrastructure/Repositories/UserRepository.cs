using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using Kanban_Board.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Kanban_Board.Infrastructure.Repositories;

public class UserRepository:IUserRepository
{
 private KanbanBoardContext _context;
 private  UserManager<ApplicationUser> _userManager;
 public UserRepository(KanbanBoardContext context, UserManager<ApplicationUser> userManager)
 {
     _context = context;
     _userManager = userManager;
 }

 public async Task RegisterUser(ApplicationUser applicationUser)
 {
     await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);
 }

    public async Task<string> LogInUser(ApplicationUser applicationUser)
    {
        var user = await _userManager.FindByEmailAsync(applicationUser.Email);
        if (user != null)
        {
            //Generate token And Return
            return null;
        }

        return null;
    }
}
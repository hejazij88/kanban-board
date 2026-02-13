using Azure.Core;
using Kanban_Board.Domain.IRepository;
using Kanban_Board.Domain.Models;
using Kanban_Board.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Kanban_Board.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private KanbanBoardContext _context;
    private UserManager<ApplicationUser> _userManager;
    public UserRepository(KanbanBoardContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<bool> RegisterUser(ApplicationUser applicationUser,string password)
    {
        var result = await _userManager.CreateAsync(applicationUser, password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                Console.WriteLine(error.Description);
        }
        return true;
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
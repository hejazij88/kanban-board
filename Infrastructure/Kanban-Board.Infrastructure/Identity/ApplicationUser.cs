using Kanban_Board.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Kanban_Board.Infrastructure.Identity;

public class ApplicationUser: IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<TaskBoard> TaskBoards { get; set; }
    public virtual ICollection<Board> Boards { get; set; }


}
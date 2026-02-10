using Microsoft.AspNetCore.Identity;

namespace Kanban_Board.Domain.Models;
public class ApplicationUser: IdentityUser<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public virtual ICollection<TaskBoard> TaskBoards { get; set; }
    public virtual ICollection<Board> Boards { get; set; }


}
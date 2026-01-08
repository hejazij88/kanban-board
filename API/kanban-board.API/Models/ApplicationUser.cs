using Microsoft.AspNetCore.Identity;

namespace kanban_board.API.Models;

public class ApplicationUser:IdentityUser<int>
{
    public virtual ICollection<TaskBoard> TaskBoards { get; set; }
    public virtual ICollection<Board> Boards { get; set; }


}
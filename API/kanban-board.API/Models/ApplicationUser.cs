using Microsoft.AspNetCore.Identity;

namespace kanban_board.API.Models;

public class ApplicationUser:IdentityUser
{
    public int Id { get; set; }
    public virtual ICollection<TaskBoard> TaskBoards { get; set; }
    public virtual ICollection<Board> Boards { get; set; }


}
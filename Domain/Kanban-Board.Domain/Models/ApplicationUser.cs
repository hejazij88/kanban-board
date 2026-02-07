namespace Kanban_Board.Domain.Models;

public class ApplicationUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<TaskBoard> TaskBoards { get; set; }
    public virtual ICollection<Board> Boards { get; set; }


}
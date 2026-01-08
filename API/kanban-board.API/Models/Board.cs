namespace kanban_board.API.Models;

public class Board:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Member> Members { get; set; }
    public List<KanbanList> KanbanList { get; set; }

    public int CreteBy { get; set; }
    public virtual ApplicationUser User { get; set; }
}
namespace kanban_board.API.Models;

public class Task:BaseEntity
{
    public string Summery { get; set; }
    public string Description { get; set; }
    public string TaskStatus { get; set; }

    public Board Board { get; set; }
    public int BoardId { get; set; }

    public KanbanList KanbanList { get; set; }
    public int KanbanListId { get; set; }

    public List<Member> Members { get; set; }

    public ApplicationUser User { get; set; }
    public int DoerId { get; set; }


}
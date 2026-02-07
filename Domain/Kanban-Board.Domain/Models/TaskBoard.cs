namespace Kanban_Board.Domain.Models;

public class TaskBoard:BaseEntity
{
    public string Summery { get; set; }
    public string Description { get; set; }
    public string TaskStatus { get; set; }
    public virtual KanbanList KanbanList { get; set; }
    public int KanbanListId { get; set; }

    public virtual ICollection<Member> Members { get; set; }

    public virtual ApplicationUser User { get; set; }
    public int DoerId { get; set; }


}
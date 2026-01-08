namespace kanban_board.API.Models;

public class KanbanList:BaseEntity
{
    public string Title { get; set; }
    public ICollection<TaskBoard> Tasks { get; set; }

    public virtual Board Board { get; set; }
    public int BoardId { get; set; }
}
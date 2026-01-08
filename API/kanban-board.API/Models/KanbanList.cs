namespace kanban_board.API.Models;

public class KanbanList:BaseEntity
{
    public string Title { get; set; }
    public List<Task> Tasks { get; set; }

    public Board Board { get; set; }
    public int BoardId { get; set; }
}
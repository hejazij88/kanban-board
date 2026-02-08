namespace Kanban_Board.Domain.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime ModifiedOn { get; set; }

}
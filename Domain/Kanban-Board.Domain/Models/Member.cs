namespace Kanban_Board.Domain.Models;

public class Member:BaseEntity
{
    public virtual Board Board { get; set; }
    public int BoardId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    public int UserId { get; set; }
    public virtual ChatGroup Group { get; set; }
    public int GroupId { get; set; }
}
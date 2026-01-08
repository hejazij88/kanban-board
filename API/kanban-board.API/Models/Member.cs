namespace kanban_board.API.Models;

public class Member:BaseEntity
{
    public Board Board { get; set; }
    public int BoardId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int UserId { get; set; }
    public ChatGroup Group { get; set; }
    public int GroupId { get; set; }
}
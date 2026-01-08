namespace kanban_board.API.Models;

public class ChatGroup:BaseEntity
{
    public string Name { get; set; }
    public int CreateByUserId { get; set; }
    public List<Member> Members { get; set; }

}
namespace kanban_board.API.Models;

public class ChatMessage:BaseEntity
{
    public string Content { get; set; }
    public DateTime SendAt { get; set; }
    public int SenderId { get; set; }
    public ChatGroup ChatGroup { get; set; }
    public int ChatGroupId { get; set; }


}
namespace Kanban_Board.Domain.Models;

    public class ChatGroup:BaseEntity
    {
        public string Name { get; set; }
        public int CreateByUserId { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }


}
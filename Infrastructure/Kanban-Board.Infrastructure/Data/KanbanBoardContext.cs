using Kanban_Board.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Board.Infrastructure.Data;

public class KanbanBoardContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
  

    public DbSet<TaskBoard> TaskBoards { get; set; }
    public DbSet<KanbanList> KanbanLists { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<ChatGroup> ChatGroups { get; set; }

    public DbSet<ChatMessage> ChatMessages { get; set; }


    public KanbanBoardContext(DbContextOptions<KanbanBoardContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // --- Board Configuration ---
        builder.Entity<Board>(entity =>
        {
            entity.HasOne(b => b.User)
                .WithMany(u=>u.Boards)
                .HasForeignKey(b => b.CreteByUser)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // --- Member Configuration (Many-to-Many Bridge) ---
        builder.Entity<Member>(entity =>
        {
            entity.HasOne(m => m.Board)
                .WithMany(b => b.Members)
                .HasForeignKey(m => m.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(m => m.ApplicationUser)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Group)
                .WithMany(g => g.Members)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.NoAction); 
        });

        // --- KanbanList Configuration ---
        builder.Entity<KanbanList>(entity =>
        {
            entity.HasOne(k => k.Board)
                .WithMany(b => b.KanbanList)
                .HasForeignKey(k => k.BoardId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // --- TaskBoard Configuration ---
        builder.Entity<TaskBoard>(entity =>
        {
            entity.HasOne(t => t.KanbanList)
                .WithMany(k => k.Tasks)
                .HasForeignKey(t => t.KanbanListId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(t => t.User)
                .WithMany(u=>u.TaskBoards)
                .HasForeignKey(t => t.DoerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // --- ChatMessage Configuration ---
        builder.Entity<ChatMessage>(entity =>
        {
            entity.HasOne(m => m.ChatGroup)
                .WithMany(t=>t.ChatMessages)
                .HasForeignKey(m => m.ChatGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // --- BaseEntity Configuration (Global Settings) ---
        builder.Entity<Board>().Property(b => b.Title).IsRequired().HasMaxLength(200);
        builder.Entity<ChatGroup>().Property(c => c.Name).IsRequired().HasMaxLength(150);
    }
}
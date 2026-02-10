using Kanban_Board.Domain.IRepository;
using Kanban_Board.Infrastructure.Data;

namespace Kanban_Board.Infrastructure.Repositories;

public class RepositoryBase<T>:IRepositoryBase<T> where T : class
{
    public KanbanBoardContext _context { get; set; }

    public RepositoryBase(KanbanBoardContext context)
    {
        _context = context;
    }

    public async void SaveChange()
    {
        await _context.SaveChangesAsync();
    }
}
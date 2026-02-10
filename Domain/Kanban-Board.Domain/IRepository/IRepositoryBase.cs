namespace Kanban_Board.Domain.IRepository;

public interface IRepositoryBase<T>
{
    public void SaveChange();
}
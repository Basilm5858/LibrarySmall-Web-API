using Library_System.Repo.Implmentation;

namespace Library_System.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        BookCustomRepo BookCustomRepo { get; }
        CategoryCustomRepo CategoryCustomRepo { get; }
        BorrowingCustomRepo BorrowingCustomRepo { get; }
        MemberCustomRepo MemberCustomRepo { get; }
        Task SaveChangesAsync();
    }
}

using Library_System.Models;
using Library_System.Repo.Interfaces;

namespace Library_System.Repo.Implmentation
{
    public class UnitOfWork : IUnitOfWork
    {
        public BookCustomRepo BookCustomRepo { get; }
        public CategoryCustomRepo CategoryCustomRepo { get; }
        public BorrowingCustomRepo BorrowingCustomRepo { get; }
        public MemberCustomRepo MemberCustomRepo { get; }
        private readonly My_AppContext _context;
        public UnitOfWork(BookCustomRepo bookCustomRepo, CategoryCustomRepo categoryCustomRepo, BorrowingCustomRepo borrowingCustomRepo, MemberCustomRepo memberCustomRepo, My_AppContext context)
        {
            BookCustomRepo = bookCustomRepo;
            CategoryCustomRepo = categoryCustomRepo;
            BorrowingCustomRepo = borrowingCustomRepo;
            MemberCustomRepo = memberCustomRepo;
            _context = context;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

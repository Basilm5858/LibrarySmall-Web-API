using Library_System.Models;
using Library_System.Repo.Interfaces;

namespace Library_System.Repo.Implmentation
{
    public class BorrowingCustomRepo : GenericRepo<Borrowing>, IBorrowing
    {
        public BorrowingCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}

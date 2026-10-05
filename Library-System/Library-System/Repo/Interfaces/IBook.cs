using Library_System.DTOs;
using Library_System.Models;

namespace Library_System.Repo.Interfaces
{
    public interface IBook : IGenericRepo<Book>
    {
        Task<ICollection<BookDTOEndPoint2>> EndPoint2(string keyword);
        Task<BookDTO> EndPoint3();
    }
}

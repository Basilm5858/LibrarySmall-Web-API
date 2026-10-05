using Library_System.DTOs;
using Library_System.Models;
using Library_System.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Repo.Implmentation
{
    public class BookCustomRepo : GenericRepo<Book>, IBook
    {
        private readonly My_AppContext _context;
        public BookCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<BookDTOEndPoint2>> EndPoint2(string keyword)
        {
            return await _context.Books
                .Where(x => x.Title.Contains(keyword) || x.Author.Contains(keyword))
                .OrderBy(x => x.Title)
                .Select(x => new BookDTOEndPoint2
                {
                    Id = x.Id,
                    Author = x.Author,
                    Price = x.Price,
                    Title = x.Title
                }).ToListAsync();
        }

        public async Task<BookDTO> EndPoint3()
        {
            return await _context.Books
                .OrderBy(x => x.Price)
                .Take(1)
                .Select(x => new BookDTO
                {
                    Id = x.Id,
                    Author = x.Author,
                    Price = x.Price,
                    Title = x.Title
                }).FirstOrDefaultAsync();

        }
    }
}

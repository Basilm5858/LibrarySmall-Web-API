using AutoMapper;
using Library_System.DTOs;
using Library_System.Models;

namespace Library_System.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookDTO, Book>();
            CreateMap<Book, BookDTO>();
            CreateMap<Book, BookDTOEndPoint2>();
        }
    }
}

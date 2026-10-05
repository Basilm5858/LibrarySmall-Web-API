using AutoMapper;
using Library_System.DTOs;
using Library_System.Models;
using Library_System.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBook repo;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IBook repo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.repo = repo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await repo.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<Category>(category);
            return Ok(res);
        }

        [HttpPost("EndPoint1")]
        public async Task<IActionResult> Create(CreateBookDTO dto)
        {
            var res = _mapper.Map<Book>(dto);
            await repo.CreateAsync(res);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetByTitleAndAuthor(string keyword)
        {
            var book = await repo.EndPoint2(keyword);
            if (book == null)
            {
                return NotFound("an appropriate empty result.");
            }
            var res = _mapper.Map<ICollection<BookDTOEndPoint2>>(book);
            return Ok(res);
        }

        [HttpGet("EndPoint3")]
        public async Task<IActionResult> GethighestPrice()
        {
            var book = await repo.EndPoint3();
            if (book == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<BookDTO>(book);
            return Ok(res);
        }
    }
}

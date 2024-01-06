using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.core.Models;
using RepositoryPattern.core.Repositories;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;
        public BooksController(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_bookRepository.GetByID(1));
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_bookRepository.Find(b=>b.Title== "new book", new[] {"Author"}));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.core.Models;
using RepositoryPattern.core.Repositories;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorRepository;
        public AuthorsController(IBaseRepository<Author> authorRepository)
        {
            _authorRepository= authorRepository;
        }
        [HttpGet]
        public IActionResult GetById() 
        {
            return Ok(_authorRepository.GetByID(1));
        }

    }
}

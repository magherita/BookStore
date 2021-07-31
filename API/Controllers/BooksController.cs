using Application.Books;
using Application.Models.Books;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<List<GetBookModel>>> GetAsync()
        {
            var response = await _bookService.GetBooks();

            return Ok(response);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookModel>> GetBookByIdAsync([FromRoute] string id)
        {
            var response = await _bookService.GetBookById(id);

            return Ok(response);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult<GetBookModel>> PostAsync([FromBody] AddBookModel model)
        {
            var response = await _bookService.CreateBook(model);

            return Ok(response);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] UpdateBookModel model)
        {
            _bookService.UpdateBook(id, model);

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            _bookService.DeleteBookById(new DeleteBookModel { Id = id });

            return NoContent();
        }
    }
}

using Application.Authors;
using Application.Models.Authors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuhtorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuhtorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuhtorsController>
        [HttpGet]
        public async Task<ActionResult<List<GetAuthorModel>>> GetAsync()
        {
            var response = await _authorService.GetAuthors();

            return Ok(response);
        }

        // GET api/<AuhtorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorModel>> GetAuthorByIdAsync([FromRoute] string id)
        {
            var response = await _authorService.GetAuthorById(id);

            return Ok(response);
        }

        // POST api/<AuhtorsController>
        [HttpPost]
        public async Task<ActionResult<GetAuthorModel>> PostAsync(
            [FromBody] AddAuthorModel model)
        {
            var response = await _authorService.CreateAuthor(model);

            return Ok(response);
        }

        // PUT api/<AuhtorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] UpdateAuthorModel model)
        {
            _authorService.UpdateAuthor(id, model);

            return NoContent();
        }

        // DELETE api/<AuhtorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            _authorService.DeleteAuthorById(new DeleteAuthorModel { Id = id });

            return NoContent();
        }
    }
}

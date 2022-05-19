using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }



        // GET: api/<PessoaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var action = await _service.GetByIdAsync(id);
                return Ok(action);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // POST api/<PessoaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa pessoa)
        {
            try
            {
                var action = await _service.CreateAsync(pessoa);
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                var action = await _service.UpdateAsync(id, pessoa);
                return Ok(action);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var action = await _service.DeleteAsync(id);
                return Ok(action);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

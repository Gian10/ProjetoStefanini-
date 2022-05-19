using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        private readonly ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }



        // GET: api/<CidadeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }



        // GET api/<CidadeController>/5
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



        // POST api/<CidadeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cidade cidade)
        {
            try
            {
                var action = await _service.CreateAsync(cidade);
                return Ok(cidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        // PUT api/<CidadeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cidade cidade)
        {
            try
            {
                var action = await _service.UpdateAsync(id, cidade);
                return Ok(action);
            }           
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<CidadeController>/5
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

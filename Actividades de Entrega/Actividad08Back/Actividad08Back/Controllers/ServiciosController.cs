using Actividad08Back.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad08Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        IServicio _repository;

        public ServiciosController(IServicio repository)
        {
            _repository = repository;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.getAll());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if(id < 1)
                {
                    return BadRequest("Dato requerido ingresado incorrectamente");
                }
                else
                {
                    return Ok(_repository.getById(id));
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

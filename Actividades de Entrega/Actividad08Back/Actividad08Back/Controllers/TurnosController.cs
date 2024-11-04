using Actividad08Back.Models;
using Actividad08Back.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad08Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        ITurnoDto _repository;

        public TurnosController(ITurnoDto repository)
        {
            _repository = repository;
        }

        // GET: api/<TurnosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_repository.getAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex);
            }
        }

        // GET api/<TurnosController>/5
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
                return StatusCode(500, ex);
            }
        }

        // POST api/<TurnosController>
        [HttpPost]
        public IActionResult Post([FromBody] TurnoDto turno)
        {
            try
            {
                if (_repository.Save(turno))
                {
                    return Ok("Turno Agregado Correctamente");
                }
                else
                {
                    return StatusCode(500, "Error al Agregar el turno");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TurnosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TurnosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

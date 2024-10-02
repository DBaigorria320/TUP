using Backend.Models;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadPractica05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private ITurnoService _servicio;

        public TurnosController(ITurnoService servicio)
        {
            _servicio = servicio;
        }

        // GET: api/<TurnosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_servicio.GetTurnos());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "ha ocurrido un error interno");
            }
        }

        // GET api/<TurnosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var turno = _servicio.GetTurnoById(id);
                    if(turno != null)
                    {
                        return Ok(turno);
                    }
                    else
                    {
                        return NotFound("Turno no encontrado");
                    }
                }
                else
                {
                    return BadRequest("Dato requerido ingresado incorrectamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "ha ocurrido un error interno");
            }
        }

        // POST api/<TurnosController>
        [HttpPost]
        public IActionResult Post([FromBody] Turno t)
        {
            try
            {
                if(IsValid(t))
                {
                    if (_servicio.SaveTurno(t))
                    {
                        return Ok("Turno agregado correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "ha ocurrido un error interno");
                    }
                }
                else
                {
                    return BadRequest("Datos requeridos ingresados incorrectamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "ha ocurrido un error interno");
            }
        }

        private bool IsValid(Turno t)
        {
            return !string.IsNullOrEmpty(t.Cliente);
        }

        // PUT api/<TurnosController>/5
        [HttpPut]
        public void Put([FromBody] Turno value)
        {
        }

        // DELETE api/<TurnosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (_servicio.DeleteTurno(id))
                    {
                        return Ok("Turno eliminado correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "ha ocurrido un error interno");
                    }
                }
                else
                {
                    return BadRequest("Dato requerido ingresado incorrectamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "ha ocurrido un error interno");
            }
        }
    }
}

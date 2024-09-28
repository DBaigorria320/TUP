using Backend.Data.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadPractica04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {

        private IServicio _servicio;

        public ServiciosController(IServicio servicio)
        {
            _servicio = servicio;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_servicio.ObtenerServicios());
            }
            catch
            {
                return StatusCode(500, "Ha ocurrido un error interno..");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var servicio = _servicio.ObtenerServicioPorId(id);
                    if (servicio != null)
                    {
                        return Ok(servicio);
                    }
                    else
                    {
                        return NotFound("Servicio no encontrado!");
                    }
                }
                else
                {
                    return BadRequest("id ingresado incorrectamente");
                }
            }
            catch
            {
                return StatusCode(500, "Ha ocurrido un error interno..");
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public void Post([FromBody] Servicio s)
        {
            try
            {
                _servicio.GuardarServicio(s);
            }
            catch
            {
                StatusCode(500, "Ha ocurrido un error interno..");
            }
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
            try
            {
                _servicio.EliminarServicio(id);
            }
            catch
            {
                StatusCode(500, "Ha ocurrido un error interno..");
            }
        }
    }
}

using Backend.Models;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadPractica05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private IServicioService _servicio;

        public ServiciosController(IServicioService servicio)
        {
            _servicio = servicio;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_servicio.GetServicios());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if(id > 0)
                {
                    var servicio = _servicio.GetServicioById(id);
                    if(servicio != null)
                    {
                        return Ok(servicio);
                    }
                    else
                    {
                        return NotFound("Servicio no encontrado");
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
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        [HttpGet("promocion")]
        public IActionResult Get([FromQuery] bool condicion)
        {
            try
            {
                return Ok(_servicio.GetAllServiciosByPromocion(condicion));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        [HttpGet("precio")]
        public IActionResult get([FromQuery] decimal precio1, decimal precio2)
        {
            try
            {
                if (IsValidPrecio(precio1, precio2))
                {
                    return Ok(_servicio.GetAllServiciosByPrecio(precio1, precio2));
                }
                else
                {
                    return BadRequest("Datos requeridos ingresados incorrectamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        private bool IsValidPrecio(decimal precio1, decimal precio2)
        {
            return precio1 < precio2 && precio1 > 0 && precio2 > 0;
        }

        // POST api/<ServiciosController>
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Servicio s)
        {
            try
            {
                if(IsValid(id, s))
                {
                    if(_servicio.SaveServicio(id, s))
                    {
                        return StatusCode(200, "Servicio agregado correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "Ha ocurrido un error interno");
                    }
                }
                else
                {
                    return BadRequest("Datos requeridos ingresados incorrectamente");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        private bool IsValid(int id, Servicio s)
        {
            return id == 0 && !string.IsNullOrEmpty(s.Nombre) && s.Costo > 0;
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Servicio s)
        {
            try
            {
                if (IsValidPut(id, s))
                {
                    s.IdServicio = id;
                    if (_servicio.SaveServicio(id, s))
                    {
                        return StatusCode(200, "Servicio actualizado correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "Ha ocurrido un error interno");
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
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        private bool IsValidPut(int id, Servicio s)
        {
            return id > 0 && !string.IsNullOrEmpty(s.Nombre) && s.Costo > 0;
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (_servicio.DeleteServicio(id))
                    {
                        return Ok("Servicio eliminado correctamente");
                    }
                    else
                    {
                        return NotFound("Servicio no encontrado");
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
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }

        [HttpDelete("promocion/{id}")]
        public IActionResult DeletePromocion(int id)
        {
            try
            {
                if(id > 0)
                {
                    if (_servicio.SacarPromocion(id))
                    {
                        return Ok("Servicio Actualizado");
                    }
                    else
                    {
                        return NotFound("Servicio no encontrado");
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
                return StatusCode(500, "Ha ocurrido un error interno");
            }
        }
    }
}

using ActividadPractica01.Domain;
using ActividadPractica01.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadPractica03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private ReceipManager _services;

        public FacturaController()
        {
            _services = new ReceipManager();
        }

        // GET: api/<FacturaController>
        [HttpGet("fecha/{date}")]
        public IActionResult GetByDate(DateTime date)
        {
            if (date != null)
            {
                return Ok(_services.GetReceipsByDate(date));
            }
            return NotFound("Factura no encontrada...");
        }

        // GET api/<FacturaController>/5
        [HttpGet("metodo/{id}")]
        public IActionResult Get(int id)
        {
            if (id != null)
            {
                return Ok(_services.GetReceipsByPaymentMethod(id));
            }
            return NotFound("Factura no encontrada...");
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Receip receip)
        {
            try
            {
                if(receip == null)
                {
                    if (_services.SaveReceip(receip))
                    {
                        return Ok("Factura agregada");
                    }
                }
                return BadRequest("Error al guardar la factura");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

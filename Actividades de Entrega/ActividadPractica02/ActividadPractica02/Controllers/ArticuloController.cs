using ActividadPractica01.Domain;
using ActividadPractica01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActividadPractica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IArticleService _service;
        
        public ArticuloController()
        {
            _service = new ArticleManager();
        }

        [HttpGet("articulos")]
        public IActionResult Get()
        {
            return Ok(_service.GetArticles());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetArticleById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Article a)
        {
            if (_service.AddArticle(a))
            {
                return Ok(a);
            }
            return BadRequest("Ocurrio un error");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeletedArticle(id))
            {
                return Ok("Articulo borrado con exito...");
            }
            return BadRequest("Ocurrio un error");
        }
    }
}

using ActividadPractica01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActividadPractica03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private ArticleManager _service;

        public ArticulosController()
        {
            _service = new ArticleManager();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetArticles());
        }
    }
}

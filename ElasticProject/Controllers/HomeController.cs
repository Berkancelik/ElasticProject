using ElasticData.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private IElasticSearchService _elasticSearchService;

        public HomeController(IElasticSearchService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }

        public HomeController()
        {

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

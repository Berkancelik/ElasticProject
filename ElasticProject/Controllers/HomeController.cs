using ElasticData.Entity;
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

   
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        private async Task InsertFullData()
        {
            new Cities { City = "Ankara", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "İç Anadolu" };
            new Cities { City = "İstanbul", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Marmara" };
            new Cities { City = "Ardahan", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Doğu Anadolu" };
            new Cities { City = "İzmir ", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Ege" };
            new Cities { City = "Samsun", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Karadeniz" };
            new Cities { City = "Rize", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Karadeniz" };
            new Cities { City = "Sivas", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Doğu Anadolu" };
            new Cities { City = "Hatay", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Güneydoğu Anadolu" };
            new Cities { City = "Diyarbakır", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Güneydoğu Anadolu" };
            new Cities { City = "Antalya", CreatedDate = DateTime.Now, Id = Guid.NewGuid().ToString(),Population = 50000, Region = "Akdeniz" };
    }
}

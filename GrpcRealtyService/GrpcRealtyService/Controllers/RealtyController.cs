using GrpcRealtyService.Internals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrpcRealtyService.Controllers
{
    [Route("api/realty")]
    public class RealtyController : Controller
    {
        IRealtyService _realtyService;
        ILogger<RealtyController> _logger;
        public RealtyController(ILogger<RealtyController> logger, IRealtyService realtyService)
        {
            _logger = logger;
            _realtyService = realtyService;
        }

        [HttpGet("{id}")]
        public IActionResult GetRealtyById(int id)
        {
            _logger.LogWarning("controller called!");
            var result = _realtyService.GetRealtyById(id);
            return Json(new { item = result, from = "answer from REST controller" });
        }

        [Authorize]
        public IActionResult GetRealtyList()
        {

            _logger.LogWarning("controller with auth called!");
            var result = _realtyService.GetRealtyList();

            return Json(result);
        }
    }
}

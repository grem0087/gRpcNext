using GrpcRealtyService.Internals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrpcRealtyService.Controllers
{
    [Route("api/realty")]
    public class RealtyController : Controller
    {
        IRealtyService _realtyService;

        public RealtyController(IRealtyService realtyService)
        {
            _realtyService = realtyService;
        }

        [HttpGet("{id}")]
        public IActionResult GetRealtyById(int id)
        {
            var result = _realtyService.GetRealtyById(id);

            return Json(result);
        }

        [Authorize]
        public IActionResult GetRealtyList()
        {
            var result = _realtyService.GetRealtyList();

            return Json(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Serverkeytool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseController : ControllerBase
    {
        [HttpPost("check")]
        public IActionResult Check([FromBody] LicenseRequest req)
        {
            if (req == null || string.IsNullOrEmpty(req.Key))
            {
                return BadRequest(new { status = "BAD_REQUEST" });
            }

            // TEST tạm – sau sẽ thay bằng DB
            if (req.Key == "TEST")
            {
                return Ok(new
                {
                    status = "OK",
                    expire = "2026-12-31"
                });
            }

            return Unauthorized(new
            {
                status = "INVALID"
            });
        }
    }

    public class LicenseRequest
    {
        public string Key { get; set; }
        public string Hwid { get; set; }
    }
}

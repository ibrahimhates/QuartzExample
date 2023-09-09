using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathIkAPI.Scheduler.Triggers;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(string ad)
        {
            var trigger = new UserActiveTrigger();

            await trigger.TriggerActiveUserAsync(ad);

            return Ok();
        }
    }
}

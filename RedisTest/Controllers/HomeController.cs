using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConnectionMultiplexer client;

        public HomeController(IConnectionMultiplexer client)
        {
            this.client= client;
        }


        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            await client.GetDatabase(0).SetAddAsync("folder","setting");
            return Content("ok");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RedisTest.Interfaces;
using RedisTest.Models;

namespace RedisTest.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RedisOperate : Controller
    {
        private readonly IRedisOperations redis;

        public RedisOperate(IRedisOperations _redis)
        {
            this.redis = _redis;
        }

        [HttpPost]
        public async Task<IActionResult>  SetValue(RedisDictionary dictionary)
        {
            var result = await redis.SetRecord(dictionary);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetValue(string Key)
        {
            var result = await redis.GetRecord(Key);
            return Ok(result);
        }
    }
}

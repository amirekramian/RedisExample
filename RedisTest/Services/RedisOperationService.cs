using RedisTest.Controllers;
using RedisTest.Interfaces;
using RedisTest.Models;
using StackExchange.Redis;

namespace RedisTest.Services
{
    public class RedisOperationService : IRedisOperations
    {

        private readonly IConnectionMultiplexer client;

        public RedisOperationService(IConnectionMultiplexer client)
        {
            this.client = client;
        }
        public async Task<string> GetRecord(string Key)
        {
            try
            {
                var result = await client.GetDatabase(0).SetMembersAsync(Key);
                var final = result.GetValue(0);
                return final.ToString();
            }
            catch
            {
                return Messages.invalidInput;
            }
                
            

        }

        public async Task<string> SetRecord(RedisDictionary dictionary)
        {
            try
            {
                await client.GetDatabase(0).SetAddAsync(dictionary.Key, dictionary.Value);
                return Messages.success;
            }
            catch
            {
                return Messages.invalidInput;
            }
            

            
        }
    }
}

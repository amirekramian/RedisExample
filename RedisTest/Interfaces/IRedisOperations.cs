using RedisTest.Models;

namespace RedisTest.Interfaces
{
    public interface IRedisOperations
    {
        Task<string> SetRecord(RedisDictionary dictionary);
        Task<string> GetRecord(string Key); 
    }
}

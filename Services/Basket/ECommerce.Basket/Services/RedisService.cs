using StackExchange.Redis;

namespace ECommerce.Basket.Services
{
    public class RedisService
    {
        private string Host { get; set; }
        private int Port { get; set; }

        private ConnectionMultiplexer _redisConnection;

        public RedisService(int port, string host)
        {
            Port = port;
            Host = host;
        }

        public void Connect() => _redisConnection = ConnectionMultiplexer.Connect($"{Host}:{Port}");

        public IDatabase GetDb(int db = 1) => _redisConnection.GetDatabase(db);


    }


}

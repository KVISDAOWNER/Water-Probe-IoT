using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }

    public interface IMongoDBSettings
    {
        string Database { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string User { get; set; }
        string Password { get; set; }

    }
}

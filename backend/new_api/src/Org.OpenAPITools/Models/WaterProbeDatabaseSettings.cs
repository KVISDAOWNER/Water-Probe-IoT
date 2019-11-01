using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.OpenAPITools.Models
{
    //TODO refactor DatabaseSettings structure
    public class WaterProbeDatabaseSettings : IWaterProbeDatabaseSettings
    {
        public string DatastreamsCollectionName { get; set; }
        public string ThingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ObservationCollectionName { get; set; }

    }

    public interface IWaterProbeDatabaseSettings
    {
        string DatastreamsCollectionName { get; set; }
        string ThingCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ObservationCollectionName { get; set; }
    }
}


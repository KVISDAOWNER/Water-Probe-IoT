using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.OpenAPITools.Models
{
    //TODO refactor DatabaseSettings structure
    public class WaterProbeDatabaseSettings : IWaterProbeDatabaseSettings
    {
        public string ProbeCollectionName { get; set; }
        public string SensorCollectionName { get; set; }
        public string LocationCollectionName { get; set; }
        public string ObservedPropertyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IWaterProbeDatabaseSettings
    {
        string ProbeCollectionName { get; set; }
        string SensorCollectionName { get; set; }
        string LocationCollectionName { get; set; }
        string ObservedPropertyCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}


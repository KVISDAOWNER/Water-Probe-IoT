﻿using MongoDB.Driver;
using Org.OpenAPITools.Models;
using Org.OpenAPITools.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.OpenAPITools.Services;


namespace Org.OpenAPITools.Services
{
    public class DatastreamService
    {
        private readonly IMongoDatabase mongoDatabase;
        private readonly ThingService thingService;
        private readonly SensorService sensorService;

        public DatastreamService(IWaterProbeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            mongoDatabase = client.GetDatabase(settings.DatabaseName);
            thingService = new ThingService(settings);
            sensorService = new SensorService(settings);
        }
 
        public List<DataStream> GetThingDatastreams(string probeId)
        {
            List<DataStream> resultDatastreams = new List<DataStream>();
            List<string> collectionNames = new List<string>();
            var probe = thingService.GetProbe(probeId);
            foreach (AttachedSensor attachedSensor in probe.AttachedSensors)
            {
                DataStream dataStream = new DataStream();
                dataStream.Name = attachedSensor.RefToSensor + "_" + probe.Id;
                dataStream.Description = attachedSensor.Description;
                
                //Hardcoded to be of obeservation type 'Observation'. The content of the result can be any type.
                dataStream.ObservationType = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_Observation";

                dataStream.UnitOfMeasurement = sensorService.GetSensor(attachedSensor.RefToSensor).UnitOfMeasurement;

                resultDatastreams.Add(dataStream);
            }
            return resultDatastreams;
        }
    }
}

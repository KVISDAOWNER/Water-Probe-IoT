/*
 * Backend API
 *
 * API for inserting data into db through sigfox custom callback
 *
 * OpenAPI spec version: 1
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;
using MongoDB.Driver;
using Org.OpenAPITools.Models;
using System.Linq;
using System.Text;

namespace IO.Swagger.Controllers
{
    public enum measurementType{
        pH,
        temperature,
        turbidity,
        nitrogen,
        phosphorus
    }

    /// <summary>
    ///
    /// </summary>
    [ApiController]
    public class DeviceDataController : ControllerBase
    {
        public DeviceDataController(IMongoDBSettings dBSettings)
        {

            MongoClient mongoClient = new MongoClient("mongodb://" + dBSettings.Host + ":" + dBSettings.Port);
            mongoDB = mongoClient.GetDatabase(dBSettings.Database);
        }
        
        public static IMongoDatabase mongoDB;
        
        private const string databaseName = "waterProbeData";

        /// <summary>
        /// Posts new data
        /// </summary>
        /// <remarks>Creates new data in db</remarks>
        /// <param name="body"></param>
        /// <response code="200">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpPost]
        [Route("/DeviceData")]
        [ValidateModelState]
        [SwaggerOperation("NewData")]
        [SwaggerResponse(statusCode: 200, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult NewData([FromBody]DeviceData body)
        {
            if (HelperFunctions.NewData(body))
                return StatusCode(200, "{\"1D95A5\":{\"downlinkData\": \"" + HelperFunctions.response + "\"}}");
            else
                return StatusCode(404, default(Sample));
        }
    }
    /// <summary>
    /// Container for helping functions
    /// </summary>
    public static class HelperFunctions
    {
        private const string turbidityName = "MJKDZ";
        private const string temperatureName = "DS18B20";
        private const string pHName = "PH4502C";
        private const string nitrogenName = "Nitrogen";
        private const string phosphorusName = "Phosphorus";
        
        private const double measurementsPerCycle = 16;
        private const double minutesPerCycle = 15;

        public static string response;

        public static bool NewData(DeviceData body)
        {
            try
            {
                var probeCollection = DeviceDataController.mongoDB.GetCollection<Probe>("Probe");
                if (probeCollection.Find(x => x.Id == body.Device).CountDocuments() == 0) // If the Probe Id is not in the data base
                {
                    Probe probe = new Probe() // We add it to the database
                    {
                        Id = body.Device,
                        AttachedSensors = new List<AttachedSensor>()
                        {
                            new AttachedSensor()
                            {
                                RefToSensor = turbidityName,
                                Description = "Water Turbidity"
                            },
                            new AttachedSensor()
                            {
                                RefToSensor = temperatureName,
                                Description = "Water Temperature"
                            },
                            new AttachedSensor()
                            {
                                RefToSensor = pHName,
                                Description = "Water pH"
                            },
                            new AttachedSensor()
                            {
                                RefToSensor = nitrogenName,
                                Description = "Water Nitrogen"
                            },
                            new AttachedSensor()
                            {
                                RefToSensor = phosphorusName,
                                Description = "Water Phosphorus"
                            }
                        },
                        Description = "New probe",
                        Locations = new List<LocationRef>(),
                        Properties = new List<string>()
                    };

                    probeCollection.InsertOne(probe);
                }

                var turbidityCollection = DeviceDataController.mongoDB.GetCollection<Observation>(turbidityName + "_" + body.Device);
                var temperatureCollection = DeviceDataController.mongoDB.GetCollection<Observation>(temperatureName + "_" + body.Device);
                var pHCollection = DeviceDataController.mongoDB.GetCollection<Observation>(pHName + "_" + body.Device);
                var nitrogenCollection = DeviceDataController.mongoDB.GetCollection<Observation>(nitrogenName + "_" + body.Device);
                var phosphorusCollection = DeviceDataController.mongoDB.GetCollection<Observation>(phosphorusName + "_" + body.Device);

                List<string> data = UnravelData(body.Data);
                List<int> timeIndices = UnravelTime(body.Data);

                DateTime startTime = DateTime.UnixEpoch.AddSeconds(int.Parse(body.Time)).Subtract(new TimeSpan(0, 15, 0));
                DateTime endTime = DateTime.UnixEpoch.AddSeconds(int.Parse(body.Time));
                string phenomenonTime = TimeToString(startTime) + "-" + TimeToString(endTime);

                Observation turbidityObservation = new Observation(phenomenonTime, TimeToString(startTime.AddMinutes(minutesPerCycle / measurementsPerCycle * timeIndices[0])), data[0]);
                Observation pHObservation = new Observation(phenomenonTime, TimeToString(startTime.AddMinutes(minutesPerCycle / measurementsPerCycle * timeIndices[1])), data[1]);
                Observation temperatureObservation = new Observation(phenomenonTime, TimeToString(startTime.AddMinutes(minutesPerCycle / measurementsPerCycle * timeIndices[2])), data[2]);
                Observation nitrogenObservation = new Observation(phenomenonTime, TimeToString(startTime.AddMinutes(minutesPerCycle / measurementsPerCycle * timeIndices[3])), data[3]);
                Observation phosphorusObservation = new Observation(phenomenonTime, TimeToString(startTime.AddMinutes(minutesPerCycle / measurementsPerCycle * timeIndices[4])), data[4]);

                turbidityCollection.InsertOne(turbidityObservation);
                temperatureCollection.InsertOne(temperatureObservation);
                pHCollection.InsertOne(pHObservation);
                nitrogenCollection.InsertOne(nitrogenObservation);
                phosphorusCollection.InsertOne(phosphorusObservation);

                response += Average(turbidityCollection, measurementType.turbidity);
                response += Average(temperatureCollection, measurementType.temperature);
                response += Average(pHCollection, measurementType.pH);
                response += Average(nitrogenCollection, measurementType.nitrogen);
                response += Average(phosphorusCollection, measurementType.phosphorus);
                while (response.Length < 16)
                {
                    response = "0" + response;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string Average(IMongoCollection<Observation> collection, measurementType measurementType)
        {
            double average = 0.0;
            double count = 0.0;
            List<Observation> list = collection.Find(x => true).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (double.TryParse(list[i].Result, out double result))
                {
                    average += result;
                    count++;
                }
            }
            double value = average / count;
            if (count == 0)
                return "0";
            else
            {
                switch (measurementType)
                {
                    case measurementType.pH:
                        return PhClamp(value);
                    case measurementType.temperature:
                        return TemperatureClamp(value);
                    case measurementType.turbidity:
                        return TurbidityClamp(value);
                    case measurementType.nitrogen:
                        return NitrogenClamp(value);
                    case measurementType.phosphorus:
                        return PhosphorusClamp(value);
                    default:
                        return "0";
                }
            }
        }

        public static string TurbidityClamp(double value) => ((int)(value * 255.0 / 3.0)).ToString("X");
        public static string PhClamp(double value) => ((int)((value - 5) * 255.0 / 4.0)).ToString("X");
        public static string TemperatureClamp(double value) => ((int)((value + 10) * 255.0 / 40.0)).ToString("X");
        public static string NitrogenClamp(double value) => ((int)value).ToString("X");
        public static string PhosphorusClamp(double value) => ((int)value).ToString("X");



        /// <summary>
        /// Unconvert from the conversion made by the Arduino.
        /// </summary>
        /// <param name="data"> byte values of data.</param>
        /// <returns> the data in readable numbers.</returns>
        public static List<string> UnravelData(string data)
        {
            List<string> result = new List<string>();
            string turbidityByte = data.Substring(0, 2);
            string pHByte = data.Substring(2, 2);
            string temperatureByte = data.Substring(4, 2);
            string nitrogenByte = data.Substring(6, 2);
            string phosphorusByte = data.Substring(8, 2);

            result.Add(UnravelTurbidity(Convert.ToInt32(turbidityByte, 16)));
            result.Add(UnravelpH(Convert.ToInt32(pHByte, 16)));
            result.Add(UnravelTemperature(Convert.ToInt32(temperatureByte, 16)));
            result.Add(UnravelNitrogen(Convert.ToInt32(nitrogenByte, 16)));
            result.Add(UnravelPhosphorus(Convert.ToInt32(phosphorusByte, 16)));

            return result;
        }

        public static string UnravelpH(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return (b * 4.0 / 253.0 + 5.0).ToString();
        }

        public static string UnravelTurbidity(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return (b * 3.0 / 253).ToString();
        }
        public static string UnravelTemperature(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return (b * 40.0 / 253.0 - 10).ToString();
        }
        public static string UnravelPhosphorus(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return b.ToString();
        }

        public static string UnravelNitrogen(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return b.ToString();
        }
        public static List<int> UnravelTime(string data)
        {
            data = data.Substring(12, 5);
            List<int> result = new List<int>();

            for (int i = 0; i < data.Length; i++)
            {
                result.Add(Convert.ToInt32(data[i].ToString(), 16));
            }

            return result;
        }

        public static string TimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
        }
    }
}

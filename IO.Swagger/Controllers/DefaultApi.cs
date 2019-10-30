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

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    { 
        /// <summary>
        /// Posts new data
        /// </summary>
        /// <remarks>Creates new data in db</remarks>
        /// <param name="body"></param>
        /// <response code="201">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpPost]
        [Route("/DeviceData")]
        [ValidateModelState]
        [SwaggerOperation("NewData")]
        [SwaggerResponse(statusCode: 201, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult NewData([FromBody]DeviceData body)
        {

            string connectionString = "mongodb://localhost:27017";

            MongoClient client = new MongoClient(connectionString);

            var observationCollection = client.GetDatabase("waterProbeData").GetCollection<DeviceData>("Observation");
            var dataStreamCollection = client.GetDatabase("waterProbeData").GetCollection<DataStream>("Datastream");



            IFindFluent<DataStream,DataStream> pHDataStream = dataStreamCollection.Find(datastream => datastream.ThingRef == body.Device && (datastream.ObservationType as string) == "pH");

            string json = JsonConvert.SerializeObject(pHDataStream.First(), Formatting.Indented);
      


            observationCollection.InsertOne(body);

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Sample));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(string));
            /*string exampleJson = null;
            exampleJson = "{\n  \"placeholder\" : \"placeholder\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Sample>(exampleJson)
                        : default(Sample);            //TODO: Change the data returned
            */
            return this.NotFound();
            //return new ObjectResult(example);
        }
        
        /// <summary>
        /// Unconvert from the conversion made by the Arduino.
        /// </summary>
        /// <param name="data"> byte values of data.</param>
        /// <returns> the data in readable numbers.</returns>
        private List<string> UnravelData(string data)
        {
            List<string> result = new List<string>();
            string turbidityByte = data.Substring(0, 2);
            string pHByte = data.Substring(2, 2);
            string temperatureByte = data.Substring(4, 2);

            result.Add(UnravelTurbidity(Convert.ToInt32(turbidityByte,16)));
            result.Add(UnravelpH(Convert.ToInt32(pHByte, 16)));
            result.Add(UnravelTemperature(Convert.ToInt32(temperatureByte, 16)));

            return result;
        }

        private string UnravelpH(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return (b * 4.0 / 253.0 + 5.0).ToString();
        }

        private string UnravelTurbidity(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return (b * 3.0 / 253).ToString();
        }
        private string UnravelTemperature(int b)
        {
            if (b == 254)
                return "too low";
            else if (b == 255)
                return "too high";
            else
                return (b * 40.0 / 253.0 - 10).ToString();
        }
    }
}

/*
 * WaterProbe API
 *
 * API for waterprobing
 *
 * The version of the OpenAPI document: 1
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using SensorThingsAPI.Attributes;
using Microsoft.AspNetCore.Authorization;
using SensorThingsAPI.Models;
using SensorThingsAPI.Services;
using SensorThingsAPI.Models.DBModels;
using SensorThingsAPI.Models.DTO;
using System.Text;

namespace SensorThingsAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ThingApiController : ControllerBase
    {
        public ThingApiController(ThingService thingService, LocationService locationService)
        {
            this._thingService = thingService;
            this._locationService = locationService;
        }

        private readonly ThingService _thingService;
        private readonly LocationService _locationService;

        /// <summary>
        /// Delete an existing probe
        /// </summary>
        /// <param name="thingname">Unique thingName</param>
        /// <response code="200">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpDelete]
        [Route("/Thing")]
        [ValidateModelState]
        [SwaggerOperation("DeleteThing")]
        [SwaggerResponse(statusCode: 200, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult DeleteThing([FromQuery]string thingname)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Sample));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(string));
            string exampleJson = null;
            exampleJson = "{\r\n  \"placeholder\" : \"placeholder\"\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Sample>(exampleJson)
            : default(Sample);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get an existing probe
        /// </summary>
        /// <param name="thingname">Unique thingName</param>
        /// <response code="200">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpGet]
        [Route("/Thing")]
        [ValidateModelState]
        [SwaggerOperation("GetThing")]
        [SwaggerResponse(statusCode: 200, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult GetThing([FromQuery]string thingname)
        {
            var probe = _thingService.GetProbe(thingname);
            var result = JsonConvert.SerializeObject(probe, Formatting.Indented);
            return new ObjectResult(result);
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Sample));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(string));
            string exampleJson = null;
            exampleJson = "{\r\n  \"placeholder\" : \"placeholder\"\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Sample>(exampleJson)
            : default(Sample);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Gets all things (probes), loops through the array of location References, finding the one with the most recent time
        /// Gets the most recent locationreference and converts it to a location.
        /// </summary>
        /// <response code="200">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpGet]
        [Route("/Things")]
        [ValidateModelState]
        [SwaggerOperation("GetThings")]
        [SwaggerResponse(statusCode: 200, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult GetThings()
        {
            List<Probe> probes;
            try
            {
                probes = _thingService.GetProbes();
                List<Thing> things = new List<Thing>();

                foreach (var probe in probes)
                {
                    string probeLocation;
                    DateTime dateTime = DateTime.MinValue;
                    DateTime dateTimeTemp;
                    probeLocation = "";
                    foreach (var loc in probe.Locations)
                    {
                        dateTimeTemp = DateTime.Parse(loc.LocationTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
                        if (dateTime < dateTimeTemp)
                        {
                            dateTime = dateTimeTemp;
                            probeLocation = loc.LocationReference;
                        }
                    }
                    var location = _locationService.GetLocation(probeLocation);
                    things.Add(new Thing(probe, location));
                }
                string result = JsonConvert.SerializeObject(things, Formatting.Indented);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Sample));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(string));
        }

        /// <summary>
        /// Creates a new probe
        /// </summary>
        /// <remarks>Creates new thing</remarks>
        /// <param name="thing">Optional properties represented as json for the Thing</param>
        /// <response code="201">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpPost]
        [Route("/Thing")]
        [ValidateModelState]
        [SwaggerOperation("NewThing")]
        [SwaggerResponse(statusCode: 201, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult NewThing([FromBody]Thing thing)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Sample));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(string));
            string exampleJson = null;
            exampleJson = "{\r\n  \"placeholder\" : \"placeholder\"\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Sample>(exampleJson)
            : default(Sample);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates a new probe
        /// </summary>
        /// <remarks>Creates new thing</remarks>
        /// <param name="thing">Optional properties represented as json for the Thing</param>
        /// <response code="201">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpPatch]
        [Route("/Thing")]
        [ValidateModelState]
        [SwaggerOperation("PatchThing")]
        [SwaggerResponse(statusCode: 201, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult PatchThing([FromQuery] string thingRef, [FromBody]DTOLocation dtoLocation)
        {
            try
            {
                var locationTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
                Location newLocation = new Location(dtoLocation);
                _locationService.AddLocation(newLocation);
                _thingService.AddLocationRefToProbe(thingRef, new LocationRef() { LocationReference = newLocation.Id, LocationTime = locationTime.ToString() });

                return StatusCode(200, "Succesfull patch");
            }
            catch (Exception e)
            {

                return StatusCode(404, e.Message);
            }
        }
    }
}

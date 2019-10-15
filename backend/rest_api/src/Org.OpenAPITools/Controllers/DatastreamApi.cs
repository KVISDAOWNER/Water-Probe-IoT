/*
 * waterprobing
 *
 * API for waterprobing
 *
 * The version of the OpenAPI document: 1
 * Contact: sw708e19@gmail.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Org.OpenAPITools.Attributes;
using Microsoft.AspNetCore.Authorization;
using Org.OpenAPITools.Models;

namespace Org.OpenAPITools.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DatastreamApiController : ControllerBase
    { 
        /// <summary>
        /// deletes a datastream
        /// </summary>
        /// <param name="dataStreamName">Unique dataStreamName</param>
        /// <response code="200">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpDelete]
        [Route("/data/2.5/dataStream")]
        [ValidateModelState]
        [SwaggerOperation("DeleteDatastream")]
        [SwaggerResponse(statusCode: 200, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult DeleteDatastream([FromQuery]string dataStreamName)
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
        /// Gets a datastream
        /// </summary>
        /// <param name="dataStreamName">Unique dataStreamName</param>
        /// <response code="200">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpGet]
        [Route("/data/2.5/dataStream")]
        [ValidateModelState]
        [SwaggerOperation("GetDatastream")]
        [SwaggerResponse(statusCode: 200, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult GetDatastream([FromQuery]string dataStreamName)
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
        /// posts a datastream
        /// </summary>
        /// <param name="dataStream">Optional properties represented as json for the dataStream</param>
        /// <response code="201">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpPost]
        [Route("/data/2.5/dataStream")]
        [ValidateModelState]
        [SwaggerOperation("PostDatastream")]
        [SwaggerResponse(statusCode: 201, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult PostDatastream([FromBody]DataStream dataStream)
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
        /// put to a datastream
        /// </summary>
        /// <param name="dataStream">Optional properties represented as json for the dataStream</param>
        /// <param name="dataStreamName">Unique dataStreamName</param>
        /// <response code="201">Successful response</response>
        /// <response code="404">Not created response</response>
        [HttpPut]
        [Route("/data/2.5/dataStream")]
        [ValidateModelState]
        [SwaggerOperation("PutDatastream")]
        [SwaggerResponse(statusCode: 201, type: typeof(Sample), description: "Successful response")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Not created response")]
        public virtual IActionResult PutDatastream([FromBody]DataStream dataStream, [FromQuery]string dataStreamName)
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
    }
}

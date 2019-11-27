using Org.OpenAPITools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    /// <summary>
    /// This is the class we use for setting into the database.
    /// </summary>
    public class Observation
    {
        public string phenomenonTime;
        public string resultTime;
        public string result;

        public Observation(string phenomenonTime, string resultTime, string result)
        {
            this.phenomenonTime = phenomenonTime;
            this.resultTime = resultTime;
            this.result = result;
        }
    }
}

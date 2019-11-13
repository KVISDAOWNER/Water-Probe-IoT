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
        public string PhenomenonTime;
        public string ResultTime;
        public string Result;

        public Observation(string phenomenonTime, string resultTime, string result)
        {
            PhenomenonTime = phenomenonTime;
            ResultTime = resultTime;
            Result = result;
        }
    }
}

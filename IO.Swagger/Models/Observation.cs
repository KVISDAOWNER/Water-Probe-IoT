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
        public TmObject TmObject;
        public TmInstant TmInstant;
        public double Result;

        public Observation(TmObject tmObject, TmInstant tmInstant, double result)
        {
            TmObject = tmObject;
            TmInstant = tmInstant;
            Result = result;
        }
    }
}

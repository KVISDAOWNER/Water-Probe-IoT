﻿using Org.OpenAPITools.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.OpenAPITools.Models.DTO
{
    public class DTOLocation
    {
        public string Description { get; set; }
        public string EncodingType { get; set; }
        public LatLong _Location { get; set; }
    }
}

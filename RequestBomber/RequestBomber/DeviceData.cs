using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestBomber
{
    class DeviceData
    {
        public DeviceData(string device, string data, string time)
        {
            this.device = device;
            this.data = data;
            this.time = time;

        }

        public string device;
        public string data;
        public string time;
    }
}

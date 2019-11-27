using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RequestBomber
{
    class Program
    {
        static void Main(string[] args)
        {
           
            RequestBomber rb = new RequestBomber();
            //Task.run returns a task with work to be done.
            var t = Task.Run(() => rb.bomb("http://localhost:50352/DeviceData"));
            //Waiting for the work to finish
            t.Wait();
        }
    }


}

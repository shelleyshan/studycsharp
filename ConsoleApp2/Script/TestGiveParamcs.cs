using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Script
{
    public class TestGiveParamcs
    {
        public List<string> param = new List<string>() { "p1", "p2", "p3" };

        public void Test()
        {
            var temp1 = param;
            param = null;
            Console.WriteLine(JsonConvert.SerializeObject(temp1));
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJSON
{
    public class Politic : Person
    {
        public string Party { get; set; }
        [JsonProperty("position")] public string Position { get; set; }

    }
}

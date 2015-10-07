using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tehtava7Juna
{
    public class Train
    {
        // i like trains..

        [JsonProperty("trainNumber")]
        public string Juna { get; set; }

        [JsonProperty("cancelled")]
        public string Peruutettu { get; set; }

        [JsonProperty("departureDate")]
        public DateTime PVM { get; set; }
    }
}

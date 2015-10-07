using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tehtava7Juna
{
    class Station
    {
        [JsonProperty("stationName")]
        public string Nimi { get; set; }

        [JsonProperty("stationShortCode")]
        public string Koodi { get; set; }

        // testinä
        // laitetaan Station-luokan lista comboboksiin
        // ja tämän avulla näytetään vain nimi
        // näin ollen stationShorCode säilyy ja se voidaan hakea
        // comboboksista myöhemmin.
        public override string ToString()
        {
            return Nimi;
        }
        // ps. ei kovin hyvä tapa..
    }
}

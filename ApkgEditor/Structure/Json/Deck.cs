using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApkgEditor.Structure
{
    public partial class Deck:JListObj
    {
        [JsonPropertyName("collapsed")]
        public bool Collapsed { get; set; }

        [JsonPropertyName("conf")]
        public long Conf { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("dyn")]
        public long Dyn { get; set; }

        [JsonPropertyName("extendNew")]
        public long ExtendNew { get; set; }

        [JsonPropertyName("extendRev")]
        public long ExtendRev { get; set; }

        //[JsonPropertyName("id")]
        //public long Id { get; set; }

        [JsonPropertyName("lrnToday")]
        public List<long> LrnToday { get; set; }

        //[JsonPropertyName("mod")]
        //public long Mod { get; set; }

        //[JsonPropertyName("name")]
        //public string Name { get; set; }

        [JsonPropertyName("newToday")]
        public List<long> NewToday { get; set; }

        [JsonPropertyName("revToday")]
        public List<long> RevToday { get; set; }

        [JsonPropertyName("timeToday")]
        public List<long> TimeToday { get; set; }

        [JsonPropertyName("usn")]
        public long Usn { get; set; }
    }
}

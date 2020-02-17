using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApkgEditor.Structure
{
    public partial class DeckConfig:JListObj
    {
        [JsonPropertyName("autoplay")]
        public bool Autoplay { get; set; }

        //[JsonPropertyName("id")]
        //public long Id { get; set; }

        [JsonPropertyName("lapse")]
        public Lapse Lapse { get; set; }

        [JsonPropertyName("maxTaken")]
        public long MaxTaken { get; set; }

        //[JsonPropertyName("mod")]
        //public long Mod { get; set; }

        //[JsonPropertyName("name")]
        //public string Name { get; set; }

        [JsonPropertyName("new")]
        public New New { get; set; }

        [JsonPropertyName("replayq")]
        public bool Replayq { get; set; }

        [JsonPropertyName("rev")]
        public Review Rev { get; set; }

        [JsonPropertyName("timer")]
        public long Timer { get; set; }

        [JsonPropertyName("usn")]
        public long Usn { get; set; }
    }

    public partial class Lapse
    {
        [JsonPropertyName("delays")]
        public List<long> Delays { get; set; }

        [JsonPropertyName("leechAction")]
        public long LeechAction { get; set; }

        [JsonPropertyName("leechFails")]
        public long LeechFails { get; set; }

        [JsonPropertyName("minInt")]
        public long MinInt { get; set; }

        [JsonPropertyName("mult")]
        public long Mult { get; set; }
    }

    public partial class New
    {
        [JsonPropertyName("bury")]
        public bool Bury { get; set; }

        [JsonPropertyName("delays")]
        public List<long> Delays { get; set; }

        [JsonPropertyName("initialFactor")]
        public long InitialFactor { get; set; }

        [JsonPropertyName("ints")]
        public List<long> Ints { get; set; }

        [JsonPropertyName("order")]
        public long Order { get; set; }

        [JsonPropertyName("perDay")]
        public long PerDay { get; set; }

        [JsonPropertyName("separate")]
        public bool Separate { get; set; }
    }

    public partial class Review
    {
        [JsonPropertyName("bury")]
        public bool Bury { get; set; }

        [JsonPropertyName("ease4")]
        public double Ease4 { get; set; }

        [JsonPropertyName("fuzz")]
        public double Fuzz { get; set; }

        [JsonPropertyName("hardFactor")]
        public double HardFactor { get; set; }

        [JsonPropertyName("ivlFct")]
        public long IvlFct { get; set; }

        [JsonPropertyName("maxIvl")]
        public long MaxIvl { get; set; }

        [JsonPropertyName("minSpace")]
        public long MinSpace { get; set; }

        [JsonPropertyName("perDay")]
        public long PerDay { get; set; }
    }
}

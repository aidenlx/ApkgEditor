using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApkgEditor.Structure
{
    //需要动态类型，More values may be added to it by any add-on
    //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to#handle-overflow-json
    public partial class Conf
    {
        [JsonPropertyName("activeDecks")]
        public List<long> ActiveDecks { get; set; }

        [JsonPropertyName("addToCur")]
        public bool AddToCur { get; set; }

        [JsonPropertyName("collapseTime")]
        public long CollapseTime { get; set; }

        [JsonPropertyName("curDeck")]
        public long CurDeck { get; set; }

        [JsonPropertyName("curModel")]
        public string CurModel { get; set; }

        [JsonPropertyName("dayLearnFirst")]
        public bool DayLearnFirst { get; set; }

        [JsonPropertyName("dueCounts")]
        public bool DueCounts { get; set; }

        [JsonPropertyName("estTimes")]
        public bool EstTimes { get; set; }

        [JsonPropertyName("newBury")]
        public bool NewBury { get; set; }

        [JsonPropertyName("newSpread")]
        public long NewSpread { get; set; }

        [JsonPropertyName("nextPos")]
        public long NextPos { get; set; }

        [JsonPropertyName("sortBackwards")]
        public bool SortBackwards { get; set; }

        [JsonPropertyName("sortType")]
        public string SortType { get; set; }

        [JsonPropertyName("timeLim")]
        public long TimeLim { get; set; }
    }
}

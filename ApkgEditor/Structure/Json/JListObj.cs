using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApkgEditor.Structure
{
    public class JListObj
    {
        //NeedSerializationOrder
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// Last modification time
        /// </summary>
        [JsonPropertyName("mod")]
        public long ModTime { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

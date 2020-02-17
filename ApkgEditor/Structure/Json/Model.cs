using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ApkgEditor.Structure
{    /// <summary>
     /// Aka Note Type
     /// </summary>
    public partial class Model:JListObj
    {
        [JsonPropertyName("css")]
        public string Css { get; set; }

        [JsonPropertyName("did")]
        public long Did { get; set; }

        [JsonPropertyName("flds")]
        public List<Field> Flds { get; set; }

        //[JsonPropertyName("id")]
        //public long Id { get; set; }

        [JsonPropertyName("latexPost")]
        public string LatexPost { get; set; }

        [JsonPropertyName("latexPre")]
        public string LatexPre { get; set; }

        //[JsonPropertyName("mod")]
        //public long Mod { get; set; }

        //[JsonPropertyName("name")]
        //public string Name { get; set; }

        /*Array of arrays describing, for each template T, which fields are required to generate T.
             The array is of the form [T,string,list], where:
             -  T is the ordinal of the template. 
             - The string is 'none', 'all' or 'any'. 
             - The list contains ordinal of fields, in increasing order.
             The meaning is as follows:
             - if the string is 'none', then no cards are generated for this template. The list should be empty.
             - if the string is 'all' then the card is generated only if each field of the list are filled
             - if the string is 'any', then the card is generated if any of the field of the list is filled.
             The algorithm to decide how to compute req from the template is explained on: 
             https://github.com/Arthur-Milchior/anki/blob/commented/documentation//templates_generation_rules.md*/
        [JsonPropertyName("req")]
        public List<List<Object>> Required { get; set; }

        [JsonPropertyName("sortf")]
        public long Sortf { get; set; }

        [JsonPropertyName("tags")]
        public List<object> Tags { get; set; }
        /// <summary>
        /// Array containing object of CardTemplate for each card in model
        /// </summary>
        [JsonPropertyName("tmpls")]
        public List<Template> Templates { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("usn")]
        public long Usn { get; set; }

        [JsonPropertyName("vers")]
        public List<object> Vers { get; set; }
    }
    /// <summary>
    /// Field Configuration
    /// </summary>
    public partial class Field
    {
        [JsonPropertyName("font")]
        public string Font { get; set; }

        [JsonPropertyName("media")]
        public List<object> Media { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ord")]
        public long Order { get; set; }

        [JsonPropertyName("rtl")]
        public bool Rtl { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("sticky")]
        public bool Sticky { get; set; }
    }

    public partial class Template
    {
        [JsonPropertyName("aFmt")]
        public string AnswerFmt { get; set; }

        [JsonPropertyName("baFmt")]
        public string BAnswerFmt { get; set; }

        [JsonPropertyName("bqFmt")]
        public string BQuestionFmt { get; set; }

        [JsonPropertyName("did")]
        public object Did { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ord")]
        public long Ord { get; set; }

        [JsonPropertyName("qFmt")]
        public string QuestionFmt { get; set; }
    }
}

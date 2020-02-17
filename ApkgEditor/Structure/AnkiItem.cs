using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ApkgEditor.Structure
{
    public static class JsonHelper
    {
        public static List<T> GetObjs<T>(string json)
        {
            List<T> objs = new List<T>();
            var a = JsonDocument.Parse(json);
            foreach (var e in a.RootElement.EnumerateObject())
            {
                objs.Add(JsonSerializer.Deserialize<T>(e.Value.GetRawText()));
            }
            return objs;
        }
        public static List<T> GetObjs<T>(Utf8JsonReader reader)
        {
            throw new NotImplementedException();
            List<T> objs = new List<T>();
            reader.Read();
        }
        public static bool GetJson<T>(List<T> objs, string path)
        {
            return GetJson(objs, File.Create(path));
        }
        public static string GetJson<T>(List<T> objs)
        {
            var memory = new MemoryStream();
            if (GetJson(objs, memory))
            {
                return Encoding.UTF8.GetString(memory.ToArray());
            }
            else
            {
                return null;
            }
        }
        private static bool GetJson<T>(List<T> objs, Stream stream)
        {
            if (typeof(T).IsSubclassOf(typeof(JListObj)))
            {
                //默认仅处理ASCII，必须指定Encoder
                //Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to#customize-character-encoding
                var sOptions = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                };
                var wOptions = new JsonWriterOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    
                };
                //try catch?
                using (Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream, wOptions))
                {
                    jsonWriter.WriteStartObject();
                    foreach (object item in objs)
                    {
                        jsonWriter.WritePropertyName((item as JListObj).Id.ToString());
                        JsonSerializer.Serialize(jsonWriter, item, item.GetType(), sOptions);
                        jsonWriter.Flush();
                    }
                    jsonWriter.WriteEndObject();
                    jsonWriter.Flush();
                }
                return true;
            }
            else return false;
        }
    }
    public class DbItem
    {

    }
}

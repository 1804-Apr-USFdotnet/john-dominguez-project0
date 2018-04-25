using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class Serializer
    {
        public static void Serialize(Object type, string filename="data.txt")
        {
            JsonSerializer serializer = new JsonSerializer {NullValueHandling = NullValueHandling.Ignore};

            using (StreamWriter streamWriter = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, type);
            }
        }

        public static string Serialize<T>(T type)
        {
            return JsonConvert.SerializeObject(type);
        }

        public static List<T> Deserialize<T>(string filename)
        {
            var jsonFile = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<T>>(jsonFile);
        }
    }
}

using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace library
{
    public class SerializeMe
    {
        public static void SerializeMeNow<T>(T type, string filename)
        {
            Console.WriteLine(JsonConvert.SerializeObject(type));
            JsonSerializer serializer = new JsonSerializer {NullValueHandling = NullValueHandling.Ignore};
        
            using (StreamWriter streamWriter = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, type);
            }
        }

        public static List<T> DeserializeMeNow<T>(string filename)
        {
            var jsonFile = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<T>>(jsonFile);
        }
    }
}

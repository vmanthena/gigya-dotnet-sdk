namespace Gigya.Socialize.SDK.Json
{
    using System.IO;
    using System.Runtime.InteropServices.ComTypes;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using System;

    public class TextJsonManager<T> : IJsonManager<T>
    {
        public T FromJson(string json)
        {
            var jsonObject = JsonConvert.DeserializeObject<T>(json);
            return jsonObject;
        }

        public string ToJson(T data)
        {
            var jsonString = JsonConvert.SerializeObject(data);
            return jsonString;
        }
    }
}

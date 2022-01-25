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

        public T DeepClone(T source)
        {

            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", nameof(source));
            }
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null)) return default;

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            using(var stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                var clonedObject =  (T)formatter.Deserialize(stream);
                return clonedObject;
            }
            
            
           
           
        }

    }
}

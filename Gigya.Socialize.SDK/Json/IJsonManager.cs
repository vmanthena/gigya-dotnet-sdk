namespace Gigya.Socialize.SDK.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    internal interface IJsonManager<T>
    {
        T FromJson(string json);
        
        string ToJson(T data);

        T DeepClone(T data);
    }
}

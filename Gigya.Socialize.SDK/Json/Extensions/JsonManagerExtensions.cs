namespace Gigya.Socialize.SDK.Json.Extensions
{
    using System.IO;

    public static class JsonManagerExtensions
    {
        public static string ToJson<T>(this T data)
            => (new TextJsonManager<T>()).ToJson(data);
        public static T FromJson<T>(this string json)
            => (new TextJsonManager<T>()).FromJson(json);
    }
}

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public static class Service
{
    /// <summary>
    /// Creates a deep copy of an object.
    /// </summary>
    /// <param name="obj">Object to copy.</param>
    /// <typeparam name="T">Type of an object.</typeparam>
    /// <returns></returns>
    public static T DeepClone<T>(this T obj)
    {
        using var ms = new MemoryStream();
        // TODO: Some other serialization?
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        var clone = JsonConvert.DeserializeObject<T>(json);
        if (clone == null)
        {
            throw new NullReferenceException("Cloning resulted in a null");
        }

        return clone;
    }
}
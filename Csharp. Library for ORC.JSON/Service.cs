using System.Runtime.Serialization.Formatters.Binary;

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
        // TODO: Binary serialization or some other serialization?
        var formatter = new BinaryFormatter();
        formatter.Serialize(ms, obj);
        ms.Position = 0;

        return (T) formatter.Deserialize(ms);
    }
}
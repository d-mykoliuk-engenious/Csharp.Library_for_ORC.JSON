using Csharp._Library_for_ORC.JSON;

public class Program
{
    static void Main()
    {
        var collection = ORCCollection.CreateExampleCollection();
        collection.WriteToFile($@"g:\CRF collection files\{DateTime.Now:yyyy-MM-dd} Win CRF.json");
    }
}

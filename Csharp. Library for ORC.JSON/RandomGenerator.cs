namespace Csharp._Library_for_ORC.JSON;

public static class RandomGenerator
{
    private static readonly Random Random = new();

    public static string GetRandomId(int digits = 10)
    {
        byte[] buffer = new byte[digits / 2];
        Random.NextBytes(buffer);
        string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
        if (digits % 2 == 0)
        {
            return result;
        }

        return result + Random.Next(16).ToString("X");
    }
}
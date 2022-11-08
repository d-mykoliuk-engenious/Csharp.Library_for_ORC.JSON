namespace Csharp._Library_for_ORC.JSON;

public static class RandomGenerator
{
    private static Random _random = new Random();

    public static string GetRandomId(int digits = 10)
    {
        byte[] buffer = new byte[digits / 2];
        _random.NextBytes(buffer);
        string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
        if (digits % 2 == 0)
        {
            return result;
        }

        return result + _random.Next(16).ToString("X");
    }
}
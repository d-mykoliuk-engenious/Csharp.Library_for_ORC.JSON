namespace Csharp._Library_for_ORC.JSON;

public class ORCParameter
{
    public (KeyValuePair<string, string>, KeyValuePair<string, string>) Parameter;

    public ORCParameter()
    {
        Parameter = (new KeyValuePair<string, string>("name", "paramName"), new KeyValuePair<string, string>("value", "paramValue"));
    }

    public ORCParameter(string paramName, string paramValue)
    {
        Parameter = (new KeyValuePair<string, string>("name", paramName), new KeyValuePair<string, string>("value", paramValue));
    }
}
namespace Csharp._Library_for_ORC.JSON;

public class ORCAttachment
{
    public Dictionary<string, string> Parameters;

    public ORCAttachment()
    {
        Parameters = new Dictionary<string, string>
        {
            {"size", "0"},
            {"uid", ""},
            {"name", ""},
            {"source", ""},
            {"type", ""}
        };
    }
    
    public ORCAttachment(string size, string uid, string name, string source, string type)
    {
        Parameters = new Dictionary<string, string>
        {
            {"size", size},
            {"uid", uid},
            {"name", name},
            {"source", source},
            {"type", type}
        };
    }

    public ORCAttachment(Dictionary<string, string> parameters)
    {
        Parameters = parameters;
    }
}
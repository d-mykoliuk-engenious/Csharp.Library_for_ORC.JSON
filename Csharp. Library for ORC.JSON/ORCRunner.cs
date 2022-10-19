namespace Csharp._Library_for_ORC.JSON;

public class ORCRunner
{
    public Dictionary<string, string> Runner_params;

    public ORCRunner()
    {
        Runner_params = new Dictionary<string, string>
        {
            {"id", "runner_id"},
            {"os", "runner_os"}
        };
    }
}
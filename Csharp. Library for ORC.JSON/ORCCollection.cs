namespace Csharp._Library_for_ORC.JSON;

public class ORCCollection
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    public ORCTestSuite[] test_suites;

    public ORCCollection()
    {
        extended_parameters = new[] {new ORCParameter()};
        tags = new[] {new ORCParameter("tag_name", "tag_value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
        test_suites = new[] {new ORCTestSuite()};
    }
}
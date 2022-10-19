namespace Csharp._Library_for_ORC.JSON;

public class ORCTestSuiteRun
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    public ORCTestCase[] test_cases;

    public ORCTestSuiteRun()
    {
        extended_parameters = new[] {new ORCParameter()};
        tags = new[] {new ORCParameter("tag_name", "tag_value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
        test_cases = new[] {new ORCTestCase()};
    }
}
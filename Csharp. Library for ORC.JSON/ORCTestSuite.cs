namespace Csharp._Library_for_ORC.JSON;

public class ORCTestSuite
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    public ORCTestSuiteRun[] test_suite_runs;

    public ORCTestSuite()
    {
        extended_parameters = new[] {new ORCParameter()};
        tags = new[] {new ORCParameter("tag_name", "tag_value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
        test_suite_runs = new[] {new ORCTestSuiteRun()};
    }
}
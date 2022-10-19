namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCase
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    public OrcTestCaseRun[] test_case_runs;

    public ORCTestCase()
    {
        extended_parameters = new[] {new ORCParameter("tc_param_Name", "tc_param_Value")};
        tags = new[] {new ORCParameter("tc_tag_Name", "tc_tag_Value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
        test_case_runs = new[] {new OrcTestCaseRun()};
    }
}
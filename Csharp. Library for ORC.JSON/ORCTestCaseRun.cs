namespace Csharp._Library_for_ORC.JSON;

public class OrcTestCaseRun
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    public ORCTestCaseStep[] pre_test_steps;
    public ORCTestCaseStep[] test_steps;
    public ORCTestCaseStep[] post_test_steps;

    public OrcTestCaseRun()
    {
        extended_parameters = new[] {new ORCParameter("tcr_param_Name", "tcr_param_Value")};
        tags = new[] {new ORCParameter("tcr_tag_Name", "tcr_tag_Value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
        pre_test_steps = new[] {new ORCTestCaseStep()};
        test_steps = new[] {new ORCTestCaseStep()};
        post_test_steps = new[] {new ORCTestCaseStep()};
    }
}
namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCaseStep
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    public ORCTestCaseStepRun[] test_step_runs;

    public ORCTestCaseStep()
    {
        extended_parameters = new[] {new ORCParameter("step_param_Name", "step_param_Value")};
        tags = new[] {new ORCParameter("step_tag_Name", "step_tag_Value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
        test_step_runs = new[] {new ORCTestCaseStepRun()};
    }
}

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCaseStepRun
{
    public ORCParameter[] extended_parameters;
    public ORCParameter[] tags;
    public ORCAttachment[] attachments;
    public ORCRunner[] runners;
    
    public ORCTestCaseStepRun()
    {
        extended_parameters = new[] {new ORCParameter("stepRun_param_Name", "stepRun_param_Value")};
        tags = new[] {new ORCParameter("stepRun_tag_Name", "stepRun_tag_Value")};
        attachments = new[] {new ORCAttachment()};
        runners = new[] {new ORCRunner()};
    }
}
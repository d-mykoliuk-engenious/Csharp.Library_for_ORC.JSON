using Newtonsoft.Json;

namespace Csharp._Library_for_ORC.JSON;

public class ORCTestCaseStep
{
    [JsonProperty("test_suite_uid")] public readonly string SuiteId;
    [JsonProperty("test_case_uid")] public readonly string CaseId;
    [JsonProperty("test_case_step_uid")] public readonly string Id;
    [JsonProperty("test_case_step_name")] public readonly string Name;
    [JsonProperty("test_case_step_max_runs_count")] public int MaxRuns;
    [JsonProperty("created_at")] public readonly DateTimeOffset Created;
    [JsonProperty("updated_at")] public DateTimeOffset Updated;
    [JsonProperty("tags")] public ORCParameter[] Tags;
    [JsonProperty("extended_parameters")] public ORCParameter[] ExtParameters;
    [JsonProperty("attachments")] public ORCAttachment[] Attachments;
    [JsonProperty("runners")] public ORCRunner[] Runners;

    public ORCTestCaseStep(ORCTestCase parentCase)
    {
    }
}
